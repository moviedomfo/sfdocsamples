

import { Helper } from './helper';
import  { ImportadorFacturas } from './ImportadorFacturas';
import { AppSettings } from './settings';

//var colors = require('colors');
//var cron = require('node-cron');




const importer = new ImportadorFacturas();



// Helper.OpenFile('appsettins.json').then(res=>{

//     let setting:AppSettings = JSON.parse(res);
   
// });
init().then(()=>{
    importer.Start().then((res)=>{
        //console.log('Staritng....');
     });
});

 



async function init() {
      try {
        let setting =  await AppSettings.create();
        console.log('Initializing ....' );
        console.log(setting );
      } catch (error) {
        console.error(`Got an error trying to write to a file: ${error.message}`);
      }
    }