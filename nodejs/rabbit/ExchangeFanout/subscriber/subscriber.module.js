'use strict'
var Person = require('./model');
const color = require('colors') 
const amqp = require('amqplib')
const queue = process.env.QUEUE || 'peopleArrivesQueue'
const exchangeName = process.env.EXCHANGE || 'peopleArrivesExchange'; 
const routingKey = process.env.ROUTING_KEY || ''; // no existe dado que es fanout
const exchangeType = 'fanout'
const wait = 400;

console.log({
    queue,
    exchangeName
})

function Subscriber(cola) {
  
    this.cola = cola;


    async function Subscribe() {
        const connection = await amqp.connect('amqp://localhost')
        const channel = await connection.createChannel()

        await channel.assertQueue(queue)

        //await channel.assertExchange(exchangeName, exchangeType)
        await channel.assertExchange(exchangeName, exchangeType, {
            durable: false // by default is true
        });

        await channel.bindQueue(queue, exchangeName)

        channel.consume(queue,async (message) => {
        
            const person = JSON.parse(message.content.toString())
            await log(person) 
            // await sleep(3000);
            // console.log(color.red('fuera del sleep'))
            channel.ack(message)
        })
    }

    subscriber().catch((error) => {
        console.error(error)
        process.exit(1)
    })

    function sleep(ms) {
        return new Promise((resolve) => {
        setTimeout(resolve,ms);
        })
    }
    function intensiveOperation() {
        let i = 1e3
        while (i--) {}
    }  
    function log(person) {
        return new Promise((resolve) => {
            const f = new Date().toISOString()
            console.log(color.blue( f + ` Received message from "${queue}" queue`))
            console.log(color.yellow( person.Lastname + ` ,` + person.FirstName))
            resolve()
        })
    

    }
}

// now we export the class, so other modules can create Subscriber objects
module.exports = {
    Subscriber: Subscriber
}