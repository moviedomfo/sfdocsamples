var amqp = require('amqplib/callback_api');
import { Color } from "colors";
import { Helper } from "../helper";
import { Person } from "../model";

const colors = require("colors");
const queue = process.env.QUEUE || 'peopleArrivesQueue';
const exchangeName = process.env.EXCHANGE || 'peopleArrivesExchange';
const exchangeType = 'fanout'
const routingKey = process.env.ROUTING_KEY || ''
const pattern = process.env.PATTERN || '';



export class Subscriber {
  
  colors: Color;

  constructor() {}

  public async Start() {
    console.log(colors.blue("------------------subscriber started--------------------") );
    // if (!AppSettings.Instance) {
    //   console.log("AppSettings.instance is not initialized");
    // }


    this.do_consume();
   // await this.DoWork() ;
    

    //  setInterval(async () => { 

    //       await this.DoWork() 

    //     },2000);
    
  }

  public async DoWork() {

    return new Promise<void>((resolve, reject) => {
        try{
           
        
          this.do_consume();
          
          resolve();
        }catch(err){
            Helper.LogErrorFull("Error al leer carpeta de cobranzas", err);
            reject(err);
        }
       

   
      });
      
  }

 
  async  do_consume(){

    const  conn = await amqp.connect('amqp://localhost');
    const  channel = await conn.createChannel();
  
    await channel.assertQueue(queue);
    await channel.assertExchange(exchangeName, exchangeType);
    await channel.bindQueue(queue, exchangeName);
    // await channel.consume(queue, function (msg) {
    //   console.log(msg.content.toString());

    //   channel.ack(msg);
    //   channel.cancel('myconsumer');
    //   }, {consumerTag: 'myconsumer'});

      
    await channel.consume(queue, (msg) => {

      //console.log(msg.content.toString());
      let p :Person=  JSON.parse(msg.content.toString()) as Person;
      this.intensiveOperation()
      console.log(p.FirstName + ' ' + p.Lastname);
      channel.ack(msg);

      channel.cancel('myconsumer');
      }, {consumerTag: 'myconsumer'});

      // setTimeout( function()  {
      //   channel.close();
      //   conn.close();}
      //   ,  500 );


    
   }
    
  
    intensiveOperation() {
      let i = 1e3;
      while (i--) {}
    }
  
}
