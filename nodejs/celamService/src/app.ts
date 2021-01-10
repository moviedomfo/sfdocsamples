
import  { ImportadorFacturas } from './ImportadorFacturas';

//var colors = require('colors');
//var cron = require('node-cron');




const importer = new ImportadorFacturas();

importer.Start().then((res)=>{
    //console.log('Staritng....');
 });
