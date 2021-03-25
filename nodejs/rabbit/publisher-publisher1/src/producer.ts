
const fs = require("fs");
const path = require("path");
var mv = require('mv');
const readline = require('readline');
var amqp = require('amqplib/callback_api');


//const faker = require('faker');
import * as faker from 'faker';
import { DateTime } from "../node_modules/luxon";
import { Color } from "colors";
import {v4 as uuidv4} from '../node_modules/uuid'
//import { faker } from "../node_modules/faker";
import { Helper } from "./helper";
import { AppSettings } from "./settings";
import { Person } from "./model";
const messagesAmount=6;
var colors = require("colors");
var cron = require("node-cron");
const exchangeName = process.env.EXCHANGE || 'peopleArrives'
const routingKey = process.env.ROUTING_KEY || ''
const exchangeType = 'direct'
const wait = 400;
const rabbitSettings ={
  protocol:'amqp',
  hostName:'localhost',
  port:5672,
  username:'guist',
  password:'guist',
  vhost:'/',
  auutMechanism:['PLAIN','AMQPLAIN','EXTERNAL']

}
export class Publisher {
  //private cronJob: CronJob;
  colors: Color;

  constructor() {}

  public async Start() {
    console.log(
      colors.blue("------------------publisher started--------------------")
    );
    if (!AppSettings.Instance) {
      console.log("AppSettings.instance is not initialized");
    }

      //runs every minute
    // cron.schedule("*/1 * * * *", async () => {
    //   await this.DoWork();
    // });
   
    

    //  setInterval(async () => { 

    //       await this.DoWork() 

    //     },2000);
        await this.DoWork2();
  }

  public  sleep(ms) {
    return new Promise((resolve) => {
      setTimeout(resolve,ms);
    })
  }

  public async  sleepLoop(number, cb) {

    while (number--){

      await this.sleep(wait);
      cb();
    }
   
 }

  public async DoWork(): Promise<void> {

    return new Promise<void>((resolve, reject) => {
        try{
            let  p:Person = Publisher.generatePerson()
            
    
            this.send(p);
            Helper.Log('enviando a la cola ' + p.GetFullName());
          
            resolve();
        }catch(err){
            Helper.LogErrorFull("Error al leer carpeta de cobranzas", err);
            reject(err);
        }
       

   
      });
      
  }

 
   public send(person:Person){
    amqp.connect('amqp://localhost', function(error0, connection) {
        if (error0) {
            throw error0;
        }
        connection.createChannel(function(error1, channel) {
            if (error1) {
                throw error1;
            }

    
    
            channel.assertExchange(exchangeName, exchangeType, {
                durable: false // by default is true
            });

            const sent = channel.publish(exchangeName, routingKey, Buffer.from(JSON.stringify(person)));

            sent
            ? console.log(`Sent person to "${exchangeName}" exchange`, person.GetFullName())
            : console.log(`Fails sending message to "${exchangeName}" exchange` )

            
        });
    
        //  setTimeout(function() {
        //      connection.close();
        //      process.exit(0);
        //  }, 500);
    });
   }
    
  
   public async DoWork2(): Promise<void> {

   
       
    let v = messagesAmount;
    amqp.connect('amqp://localhost', function(error0, connection) {
        if (error0) {
            throw error0;
        }
        connection.createChannel(function(error1, channel) {
            if (error1) {
                throw error1;
            }
            channel.assertExchange(exchangeName, 'direct', {
                durable: false // by default is true
            });
            //this.sleepLoop(this.messagesAmount, async () => {
              while (v--){
              const person = Publisher.generatePerson();
              const sent = channel.publish(
                        exchangeName, 
                        routingKey, Buffer.from(JSON.stringify(person)), {
                          // persistent: true
                      });

              sent
              ? console.log(`Sent person to "${exchangeName}" exchange`, person.GetFullName())
              : console.log(`Fails sending message to "${exchangeName}" exchange` )

               //this.sleep(wait);

            }
          //});
            
        });
    
     
    });
   
      
  }
    

   public static generatePerson():Person{
    let  p:Person = new  Person();
    p.Id = uuidv4();
    p.FirstName = faker.name.firstName();
    p.Lastname = faker.name.lastName();

    return p;
   }



}
