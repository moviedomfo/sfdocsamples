

import { Helper } from './helper';
import  { ImportadorFacturas } from './ImportadorFacturas';
import { AppSettings } from './settings';


const importer = new ImportadorFacturas();



// init().then(()=>{
//     importer.ImportarFacturas();
// });

//importer.getByNroFactura();
init().then(()=>{
    importer.Start().then((res)=>{
        console.log('End invoice importin....');
     });
});

 
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