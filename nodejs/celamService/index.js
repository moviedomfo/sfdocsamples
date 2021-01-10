const axios = require('axios').default;
var https = require('https');
const { DateTime } = require("luxon");
var colors = require('colors');
var cron = require('node-cron');

//minute hour day(month) month day (week)
//“At every minute on day-of-month 5.”

cron.schedule("* * 5 * *", () => {
    
    let dt_local= DateTime.local();
    var d = DateTime.fromISO(dt_local.toString()).toFormat('yyyy-MM-dd HH-mm-ss');
    console.log(colors.blue('facturand at : ' + d));

    
});