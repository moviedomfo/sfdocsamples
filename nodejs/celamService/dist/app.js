"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const ImportadorFacturas_1 = require("./ImportadorFacturas");
//var colors = require('colors');
//var cron = require('node-cron');
const importer = new ImportadorFacturas_1.ImportadorFacturas();
importer.Start().then((res) => {
    //console.log('Staritng....');
});
//# sourceMappingURL=app.js.map