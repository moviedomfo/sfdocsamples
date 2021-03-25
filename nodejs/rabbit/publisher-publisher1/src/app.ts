import { Helper } from './helper';
import  { Publisher } from './producer';
import { AppSettings } from './settings';

const publisher = new Publisher();

init().then(()=>{
    publisher.Start().then((res)=>{
   
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