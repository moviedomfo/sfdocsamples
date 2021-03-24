
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

var colors = require("colors");
var cron = require("node-cron");
const exchange = 'peopleArrives';

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
    cron.schedule("*/1 * * * *", async () => {
      await this.DoWork();
    });
   
    

     setInterval(async () => { 

          await this.DoWork() 

        },2000);
      
  }

  public  sleep(ms) {
    return new Promise((resolve) =>{
      setTimeout(resolve,ms);
    })
  }

  public async  sleepLoop(number,cb) {

    while (number--){

      await this.sleep(wait);
      cb();
    }
   
 }

  public async DoWork(): Promise<void> {

    return new Promise<void>((resolve, reject) => {
        try{
            let  p:Person = new  Person();
            p.Id = uuidv4();
            p.FirstName = faker.name.firstName();
            p.Lastname = faker.name.lastName();
    
            //this.send(p);
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

    
    
            channel.assertExchange(exchange, 'fanout', {
                durable: false // by default is true
            });

            channel.publish(exchange, '', Buffer.from(JSON.stringify(person)));

            console.log(" [x] Sent %s", person.GetFullName());
        });
    
        //  setTimeout(function() {
        //      connection.close();
        //      process.exit(0);
        //  }, 500);
    });
   }
    
  




}
