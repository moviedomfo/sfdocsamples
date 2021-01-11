

import { Helper } from './helper';
import  { ImportadorFacturas } from './ImportadorFacturas';
import { AppSettings } from './settings';



// let n = Helper.getPeriodo();

// console.log(n);



const importer = new ImportadorFacturas();

importer.ImportarFacturas();
//importer.getByNroFactura();
// init().then(()=>{
//     importer.Start().then((res)=>{
//         //console.log('Staritng....');
//      });
// });

 



async function init() {
      try {
        let setting =  await AppSettings.Create();
        console.log('Initializing ....' );
        Helper.Log('Initializing ....');
        console.log(setting );
      } catch (error) {
        Helper.LogError(`Got an error trying to write to a file: ${error.message}`);
        console.error(`Got an error trying to write to a file: ${error.message}`);
      }
    }