"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Helper = void 0;
const luxon_1 = require("../node_modules/luxon");
//const fs = require('fs');
const fs = require("fs");
//const settings = fs.readFileSync('appsettins.json');
class Helper {
    /*
        async function Sample()
            {
                await WriteFile("someFile.txt", "someData");
                console.log("WriteFile is finished");
            }
     */
    static WriteFile(fileName, data) {
        return new Promise((resolve, reject) => {
            fs.writeFile(fileName, data, (err) => {
                if (err) {
                    reject(err);
                }
                else {
                    resolve();
                }
            });
        });
    }
    static getTime_Iso() {
        let dt_local = luxon_1.DateTime.local();
        var d = luxon_1.DateTime.fromISO(dt_local.toString()).toFormat("yyyy-MM-dd HH-mm-ss");
        return d;
    }
}
exports.Helper = Helper;
Helper.saveFile = (fileName, content) => ({});
//# sourceMappingURL=helper.js.map