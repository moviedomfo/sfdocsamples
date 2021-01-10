

import { readFileSync } from 'fs';
import { DateTime } from "../node_modules/luxon";
import * as path from 'path';
//const fs = require('fs');
import * as fs from 'fs';

//const settings = fs.readFileSync('appsettins.json');

export class Helper {
    
    /* 
        async function Sample()
            {
                await WriteFile("someFile.txt", "someData");
                console.log("WriteFile is finished");
            }
     */
    public static WriteFile(fileName, data): Promise<void>
    {
        return new Promise<void>((resolve, reject) =>
        {
            fs.writeFile(fileName, data, (err) => 
            {
                if (err)
                {
                    reject(err);    
                }
                else
                {
                    resolve();
                }
            });
        });        
    }


    public static saveFile = (fileName:string, content:string) => ({
        
        
    });

    public static getTime_Iso(): DateTime {
        let dt_local = DateTime.local();
        var d = DateTime.fromISO(dt_local.toString()).toFormat(
          "yyyy-MM-dd HH-mm-ss"
        );
        return d;
      }
    
    // async function openFile() {
    //     try {
    //       const csvHeaders = 'name,quantity,price'
    //       await fs.writeFile('groceries.csv', csvHeaders);
    //     } catch (error) {
    //       console.error(`Got an error trying to write to a file: ${error.message}`);
    //     }
    //   }

   
}
