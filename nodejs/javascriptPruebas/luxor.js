const { DateTime } = require("luxon");
var colors = require('colors');



var local = DateTime.local();
console.log(colors.yellow('---------------DateTime.local()-----------------'));
console.log(colors.red('local.toString() : ') + colors.blue(local.toString()));
console.log(colors.red('local.zoneName : ') + colors.blue(local.zoneName));


console.log(colors.red('local DATETIME_FULL : ') + colors.blue(local.toLocaleString(DateTime.DATETIME_FULL)));

console.log(colors.red('local DATETIME_SHORT_WITH_SECONDS : ') + colors.blue(local.toLocaleString(DateTime.DATETIME_SHORT_WITH_SECONDS)));

console.log(colors.yellow('---------------------------------'));



console.log(colors.yellow('---------------DateTime.fromISO------------------'));
var iso = DateTime.fromISO(local.toString());
console.log(colors.red('iso.toString : ') + colors.blue(iso.toString()));
console.log(colors.red('iso.zoneName : ') + colors.blue(iso.zoneName));

var d = DateTime.fromISO(local.toString()).toFormat('yyyy-MM-dd HH-mm-ss');
console.log(colors.red('iso formateado : ') + colors.blue(d.toString()));
console.log(colors.yellow('---------------------------------'));


console.log(colors.yellow('---------------ISO 8601------------------'));
console.log(colors.red('local.toISO : ') + colors.blue(local.toISO()));
console.log(colors.red('local.toISODate : ') + colors.blue(local.toISODate()));
console.log(colors.yellow('---------------------------------'));



const fecha = '2021-01-22';
const convertida =  DateTime.fromISO(fecha+'T13:00:00.00');

console.log(colors.yellow('FECHA :' + fecha + ' --> ' + convertida.toSQLDate()  ));
