//import { CronJob } from '../node_modules/node-cron';
const fs = require("fs");
//var colors = require('../node_modules/colors');
//import  https  from 'https';
import { DateTime } from "../node_modules/luxon";
import { Color } from "colors";
import axios, { AxiosStatic } from "axios";
import { Helper } from "./helper";
import { AppSettings } from "./settings";
var colors = require("colors");
var cron = require("node-cron");
const https = require("https");
export class ImportadorFacturas {

  
  //private cronJob: CronJob;
  colors: Color;

  constructor() {
    // let cron: CronJob;

    // this.cronJob = new CronJob('0 0 5 * * *', async () => {
    //     try {
    //         await tarea();
    //     } catch (e) {
    //         console.error(e);
    //     }
    // });
    //Start job
    // if (!this.cronJob.running) {
    //     this.cronJob.start();
    // }

    async function tarea(): Promise<void> {
      //     // Do some task
      let dt_local = DateTime.local();
      var d = DateTime.fromISO(dt_local.toString()).toFormat(
        "yyyy-MM-dd HH-mm-ss"
      );

      console.log(colors.blue("importing invoices : " + d));
    }
  }

  public async Start() {
    const setting =  await AppSettings.Create();
    // Do some task
    console.log(
      colors.red("------------------Importer Start--------------------")
    );

    
    cron.schedule("* * * * *", () => {
      this.DoWork()
        .then(() => {
    
          //console.log(numerador);
        })
        .catch((e) => {
          console.log(colors.red(e));
        });
    });
  }
  private async DoWork(): Promise<void> {
    const url =    "https://localhost:58000/api/Facturas/ImportarFacturas";

    console.log(colors.blue("importing invoices : " + Helper.getTime_Iso()));

    const agent = new https.Agent({
        rejectUnauthorized: false
    });

    let period = Helper.getPeriodo();
   let req  = 
    {
      "year":2020,
       "month" : 12,
       "period" : "01122020"
    }
   
    axios
      .post(url, {
        httpsAgent: agent,
        data:req
      },
       )
      .then(async (res) => {
        //let resToJson = JSON.stringify(res.data);
        // await Helper.WriteFile("factura.json", resToJson);
        Helper.Log("Se lealizo la importacion de facturas periodo : " + Helper.getFileNamePrefix)
         console.log(colors.yellow('saved in factura.json'));
      })
      .catch(function (error) {
        console.log(colors.red(error));
      });
   
  }

  private async DoWorkTest(): Promise<void> {
    const url =    "https://localhost:5100/api/Facturas/getByNroFactura?nroFact=297739";

    console.log(colors.blue("importing invoices : " + Helper.getTime_Iso()));

    const agent = new https.Agent({
        rejectUnauthorized: false
    });

   
    axios
      .get(url, {
        httpsAgent: agent,
      })
      .then(async (res) => {
        let resToJson = JSON.stringify(res.data);
        await Helper.WriteFile("factura.json", resToJson);
         console.log(colors.yellow('saved in factura.json'));
        
      })
      .catch(function (error) {
        console.log(colors.red(error));
      });
   
  }


  /* only for testing purpose */
   public ImportarFacturas() {

    
    const url =    "http://localhost:58000/api/Facturas/ImportarFacturas";

    console.log(colors.blue("importing invoices : " + Helper.getTime_Iso()));

    const agent = new https.Agent({
        rejectUnauthorized: false
    });

    let period = Helper.getPeriodo();
   let req  = 
    {
      "year":2020,
       "month" : 12,
       "period" : period
    }
   
    axios
      .post(url, {
        httpsAgent: agent,
        data:req
      },
       )
      .then(async (res) => {
        //let resToJson = JSON.stringify(res.data);
        // await Helper.WriteFile("factura.json", resToJson);
        Helper.Log("Se lealizo la importacion de facturas periodo : " + Helper.getFileNamePrefix)
         console.log(colors.yellow('saved in factura.json'));
      })
      .catch(function (error) {


        Helper.LogError(JSON.stringify(error.response.data));
        
        console.log(colors.red(Helper.GetError(error)));
   
      });
   
  }


  public getByNroFactura() {

    console.log(colors.cyan('call_Axios_async1'));
    // At request level
    const agent = new https.Agent({
        rejectUnauthorized: false
    });
    const url =
      "http://localhost:5100/api/Facturas/getByNroFactura?nroFact=297739";
      
      axios
        .get(url, {
          httpsAgent: agent,
        })
        .then((res) => {
          console.log(colors.blue(res.data));
        })
        .catch(function (error) {
          console.log(colors.red(error));
        });
  }

  // private async SampleReturnPromise(): Promise<void> {
  //   return new Promise((resolve, reject) => {
  //     setTimeout(() => {
  //       // if(productos.length !==0){
  //       //     reject (new Error("error provocado"));
  //       // }
  //       //do your async steps here
  //       resolve();
  //     }, 2000);
  //   });
  // }

}
