

//const settings = fs.readFileSync('appsettins.json');

import { readFile } from "fs";
import { Helper } from "./helper";



export class AppSettings {

    public  static async create(): Promise<AppSettings>{

      let setting:   AppSettings;
      // Helper.OpenFile('appsettins.json').then( (res)=>{

      //    setting = JSON.parse(res) as AppSettings;
        
      // });
      var res = await Helper.OpenFile('appsettins.json');

      setting = JSON.parse(res) as AppSettings;
      return  setting;
    } 


    public factura: Factura;
}


export class Factura {
  public sourceFolder: string;
  public destFolder: string;
}
