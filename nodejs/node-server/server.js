var http = require('http');
var fs = require('fs');
var mainSettings =require('./setting-main.js'); 


 http.createServer(function(req,res){
     console.log('CATALINA');
     mainSettings.cnfg();
       res.end ();
 }).listen('8089');


 var leerArchivo = function(req,res){
        
        //x();
        fs.readFile("./index.html",function(err,htmlFile){
            res.writeHead(200,{"Content-Type":"text/html"});
            res.write(htmlFile);
            res.end ();
        });
 };



