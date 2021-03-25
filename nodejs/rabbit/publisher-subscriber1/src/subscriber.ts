var amqp = require('amqplib/callback_api');

import { Color } from "colors";

import { Helper } from "./helper";
import { AppSettings } from "./settings";
import { Person } from "./model";

var colors = require("colors");

const exchangeName = process.env.EXCHANGE || 'peopleArrives'
const exchangeType = 'direct'
const routingKey = process.env.ROUTING_KEY || ''
const queue = process.env.QUEUE || 'hello'
const pattern = process.env.PATTERN || ''



export class Subscriber {
  
  colors: Color;

  constructor() {}

  public async Start() {
    console.log(
      colors.blue("------------------subscriber started--------------------")
    );
    if (!AppSettings.Instance) {
      console.log("AppSettings.instance is not initialized");
    }


   
    

    //  setInterval(async () => { 

    //       await this.DoWork() 

    //     },2000);
    
  }

 

  
   
 

  public async DoWork() {

    return new Promise<void>((resolve, reject) => {
        try{
           
        
            Helper.Log('enviando a la cola ' + p.GetFullName());
          
            resolve();
        }catch(err){
            Helper.LogErrorFull("Error al leer carpeta de cobranzas", err);
            reject(err);
        }
       

   
      });
      
  }

 
  async  do_consume(person:Person){

    var conn = await amqp.connect('amqp://localhost', "heartbeat=60");
    var channel = await conn.createChannel();
    await conn.createChannel();
    await channel.assertQueue(queue, {durable: true});

    await channel.consume(queue, function (msg) {
      console.log(msg.content.toString());
      channel.ack(msg);
      channel.cancel('myconsumer');
      }, {consumerTag: 'myconsumer'});

      setTimeout( function()  {
        channel.close();
        conn.close();}
        ,  500 );


    // amqp.connect('amqp://localhost', async  (error0, connection)  => {
    //     if (error0) {
    //         throw error0;
    //     }
    //     connection.createChannel(function(error1, channel) {
    //         if (error1) {
    //             throw error1;
    //         }

    //         await channel.assertQueue(queue);
    //         await channel.bindQueue(queue, exchangeName, pattern);
    
    //         channel.assertExchange(exchangeName, exchangeType, {
    //             durable: false // by default is true
    //         });

    //         const sent = channel.publish(exchangeName, routingKey, Buffer.from(JSON.stringify(person)));

    //         sent
    //         ? console.log(`Sent person to "${exchangeName}" exchange`, person.GetFullName())
    //         : console.log(`Fails sending message to "${exchangeName}" exchange` )

            
    //     });
    
    //      setTimeout(function() {
    //          connection.close();
    //          process.exit(0);
    //      }, 500);
    // });
   }
    
  

  
}
