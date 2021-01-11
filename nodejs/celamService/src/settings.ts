import { Helper } from "./helper";
import {Category,CategoryLogger,CategoryServiceFactory,CategoryConfiguration,LogLevel} from "typescript-logging";
CategoryServiceFactory.setDefaultConfiguration(new CategoryConfiguration(LogLevel.Info));
// Create categories, they will autoregister themselves, one category without parent (root) and a child category.
// export const catService = new Category("service");
// export const catFacturas = new Category("facturas", catService);


export class AppSettings {

  public static Instance:AppSettings;

  
    public  static async Create(): Promise<AppSettings>{

      //let setting:   AppSettings;
     if(AppSettings.Instance)
      return AppSettings.Instance;
      else
      {
        var res = await Helper.OpenFile('appsettins.json');

        AppSettings.Instance = JSON.parse(res) as AppSettings;
      }
      
      return  AppSettings.Instance;
    } 


    public factura: Factura;
}


export class Factura {
  public sourceFolder: string;
  public destFolder: string;
}
