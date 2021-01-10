"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ImportadorFacturas = void 0;
//import { CronJob } from '../node_modules/node-cron';
const fs = require("fs");
//var colors = require('../node_modules/colors');
//import  https  from 'https';
const luxon_1 = require("../node_modules/luxon");
const axios_1 = require("axios");
const helper_1 = require("./helper");
var colors = require("colors");
var cron = require("node-cron");
const https = require("https");
class ImportadorFacturas {
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
        function tarea() {
            return __awaiter(this, void 0, void 0, function* () {
                //     // Do some task
                let dt_local = luxon_1.DateTime.local();
                var d = luxon_1.DateTime.fromISO(dt_local.toString()).toFormat("yyyy-MM-dd HH-mm-ss");
                console.log(colors.blue("importing invoices : " + d));
            });
        }
    }
    Start() {
        return __awaiter(this, void 0, void 0, function* () {
            // Do some task
            console.log(colors.red("------------------Importer Start--------------------"));
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
        });
    }
    DoWork() {
        return __awaiter(this, void 0, void 0, function* () {
            const url = "https://localhost:5100/api/Facturas/getByNroFactura?nroFact=297739";
            console.log(colors.blue("importing invoices : " + helper_1.Helper.getTime_Iso()));
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
            process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';
            axios_1.default
                .get(url, {
                httpsAgent: agent,
            })
                .then((res) => {
                console.log(colors.blue(res.data));
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
        });
    }
    DoWork_prueba() {
        return __awaiter(this, void 0, void 0, function* () {
            return new Promise((resolve, reject) => {
                setTimeout(() => {
                    // if(productos.length !==0){
                    //     reject (new Error("error provocado"));
                    // }
                    // do your async steps here
                    console.log(colors.blue("importing invoices : " + helper_1.Helper.getTime_Iso()));
                    resolve();
                }, 2000);
            });
        });
    }
    /* Coinvierte fecha local y retorna a formato ISO  */
    callApi() {
        console.log(colors.cyan('call_Axios_async1'));
        // At request level
        const agent = new https.Agent({
            rejectUnauthorized: false
        });
        const url = "https://localhost:5100/api/Facturas/getByNroFactura?nroFact=297739";
        axios_1.default.get(url, {
            httpsAgent: agent
        })
            .then(res => {
            console.log(colors.blue(res.data));
        }).catch(function (error) {
            console.log(colors.red(error));
        });
    }
}
exports.ImportadorFacturas = ImportadorFacturas;
//# sourceMappingURL=ImportadorFacturas.js.map