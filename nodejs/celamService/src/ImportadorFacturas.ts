//import { CronJob } from '../node_modules/node-cron';
const fs = require("fs");
//var colors = require('../node_modules/colors');
//import  https  from 'https';
import { DateTime } from "../node_modules/luxon";
import { Color } from "colors";
import axios, { AxiosStatic } from "axios";
import { Helper } from "./helper";
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
    // Do some task
    console.log(
      colors.red("------------------Importer Start--------------------")
    );
    //   let dt_local= DateTime.local();
    //   var d = DateTime.fromISO(dt_local.toString()).toFormat('yyyy-MM-dd HH-mm-ss');
    //   console.log(colors.blue('importing invoices : ' + d));
    let numerador = 0;
    cron.schedule("* * * * *", () => {
      // let dt_local= DateTime.local();
      // var d = DateTime.fromISO(dt_local.toString()).toFormat('yyyy-MM-dd HH-mm-ss');
      // console.log(colors.blue('facturando at : ' + d));
      //async () =>  this.DoWork();

      this.DoWork()
        .then(() => {
          numerador++;
          console.log(numerador);
        })
        .catch((e) => {
          console.log(colors.red(e));
        });
    });
  }

  private async DoWork(): Promise<void> {
    const url =
      "https://localhost:5100/api/Facturas/getByNroFactura?nroFact=297739";

    console.log(colors.blue("importing invoices : " + Helper.getTime_Iso()));

    const agent = new https.Agent({
        rejectUnauthorized: false
    });

   


    // axios({
    //   url: url,
    //   method: "GET",
    //   headers: {
    //     "Content-Type": "application/json",
    //   },
    //   responseType: "json",
    //   httpsAgent: new https.Agent({
    //     rejectUnauthorized: false,
    //   }),
    // })
    //   .then( (response) => { // para transformarla en async .then(async (response) => {
    //     console.log(colors.blue(response.data));
    //     // let resToJson = JSON.stringify(response.data);
    //     // await Helper.WriteFile("countries-3.json", resToJson);
       
    //   })
    //   .catch((error) => {
    //     console.log(colors.red(error));
    //   });
  
    axios
      .get(url, {
        httpsAgent: agent,
      })
      .then(async (res) => {
        let resToJson = JSON.stringify(res.data);
        await Helper.WriteFile("factura.json", resToJson);
        // .then(()=>{
         console.log(colors.yellow('saved in factura.json'));
        // });
        
      })
      .catch(function (error) {
        console.log(colors.red(error));
      });
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        // if(productos.length !==0){
        //     reject (new Error("error provocado"));
        // }
        // do your async steps here
        resolve();
      }, 2000);
    });
  }

  private async DoWork_prueba(): Promise<void> {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        // if(productos.length !==0){
        //     reject (new Error("error provocado"));
        // }
        // do your async steps here
        console.log(colors.blue("importing invoices : " + Helper.getTime_Iso()));

        resolve();
      }, 2000);
    });
  }

  /* Coinvierte fecha local y retorna a formato ISO  */
 
  public callApi() {

    console.log(colors.cyan('call_Axios_async1'));
    // At request level
    const agent = new https.Agent({
        rejectUnauthorized: false
    });
    const url =
      "https://localhost:5100/api/Facturas/getByNroFactura?nroFact=297739";
      
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
}
