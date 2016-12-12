
var settings = require('./Settings.js');


 function pepe(){
    var config =  settings.Context();
    config.Culture="En-ES";
    config.HostName="Socrates-ES";
    config.AppId="allus system globalbpo-ES";
    var jsonConfig = JSON.stringify(config);


    var config2 = new settings.Setting();
     config2.Culture="En-ES -Setting";
    config2.HostName="Setting Socrates-ES";
    jsonConfig = JSON.stringify(config2);
    console.log('por leer el archivo' + jsonConfig);
}

module.exports.cnfg = pepe;