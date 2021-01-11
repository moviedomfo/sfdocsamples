import { DateTime } from "../node_modules/luxon";
//import {catService,catFacturas} from "./settings"

//import DateTime from 'luxon/src/datetime.js'
//import { DateTime } from 'luxon/src/datetime.js'
import * as fs from 'fs';
import { readFileSync } from 'fs';
import * as path from 'path';


export class Helper {



  public static WriteFile(fileName, data): Promise<void> {
    return new Promise<void>((resolve, reject) => {
      fs.writeFile(fileName, data, (err) => {
        if (err) {
          reject(err);
        } else {
          resolve();
        }
      });
    });
  }
  public static AppendFile(fileName, data): Promise<void> {
    return new Promise<void>((resolve, reject) => {
      fs.appendFile(fileName, data, (err) => {
        if (err) {
          reject(err);
        } else {
          resolve();
        }
      });
    });
  }


  public static OpenFile(fileName: string): Promise<string> {
    return new Promise<string>((resolve, reject) => {
      var json = fs.readFileSync(fileName, "utf8");
      console.log(json);
      resolve(json);
      // fs.readFile(fileName,  (err,data) =>
      // {
      //     if (err)
      //     {
      //         reject(err);
      //     }
      //     else
      //     {
      //         resolve(data);
      //     }
      // });
    });
  }

  public static saveFile = (fileName: string, content: string) => ({

  });
  
  /* 
    Coinvierte fecha local y retorna a formato ISO  
  */
  public static getTime_Iso(): DateTime {
    let dt_local = DateTime.local();
    var d = DateTime.fromISO(dt_local.toString()).toFormat(
      "yyyy-MM-dd HH-mm-ss"
    );
    return d;
  }

  /* 
   returns yyyymmdd_ prefix
   */
  public static getFileNamePrefix(): String {

    var dt_local = DateTime.local();
  
     var d = DateTime.fromISO(dt_local.toString()).toFormat(
      "yyyyMMdd_"
    );
    return d;
  }

  public static getPeriodo(): String {

    var dt_local = DateTime.local();
    //return 01032020-
     return  DateTime.fromISO(dt_local.toString()).toFormat("ddMMyyyy-");
  }
  // async function openFile() {
  //     try {
  //       const csvHeaders = 'name,quantity,price'
  //       await fs.writeFile('groceries.csv', csvHeaders);
  //     } catch (error) {
  //       console.error(`Got an error trying to write to a file: ${error.message}`);
  //     }
  //   }

  public static Log(message: string): void {
    try{
      let logFileName = Helper.getFileNamePrefix() + "logs.txt";
      let log = Helper.getTime_Iso() + ' INFO ';
      log = log.concat( message , '\n');
      Helper.AppendFile(logFileName, log);
    }catch (error) {
      console.error(`Got an error trying to write to a file: ${error.message}`);
    } 
    
    
  }

  public static LogError(message: string): void {
    let logFileName = Helper.getFileNamePrefix() + "logs.txt";
    let log = Helper.getTime_Iso() + ' ERROR ';
    log = log.concat( message , '\n');
    Helper.AppendFile(logFileName, log);
  }


  public static GetError(error): void {
    let message = error.message;
    message = message.concat(error.response.data.Message, '\n');
    return message;
  }


  // public static Log = (message: string) => ({

  //   Helper.catFacturas.info(() => message);
  //   Helper.catFacturas.info(() => "Performing magic once more: " + name);
  // });
  
}
