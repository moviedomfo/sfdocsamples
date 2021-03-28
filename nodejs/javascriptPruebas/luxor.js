const { DateTime } = require("luxon");
const {Settings} =  require("luxon");
var colors = require('colors');

Settings.defaultLocale = 'es';

var local = DateTime.local().setLocale('es');

DateTime.now()
  .setLocale("es")
  .toLocaleString(DateTime.DATE_FULL); 

console.log(colors.yellow(DateTime.now().setLocale('es').toLocaleString(DateTime.DATETIME_FULL)));

console.log(colors.yellow('---------------DateTime.local()-----------------'));
console.log(colors.red('local.toString() : ') + colors.blue(local.toString()));
console.log(colors.red('local.zoneName : ') + colors.blue(local.zoneName));

console.log(colors.red('local DATE_HUGE : ') + colors.blue(local.toLocaleString(DateTime.DATE_HUGE)));
console.log(colors.red('local DATETIME_FULL : ') + colors.blue(local.toLocaleString(DateTime.DATETIME_FULL)));
console.log(colors.red('local DATETIME_SHORT_WITH_SECONDS : ') + colors.blue(local.toLocaleString(DateTime.DATETIME_SHORT_WITH_SECONDS)));

console.log(colors.yellow('----------------setZone-----------------'));
let fecha = local.setZone('America/Buenos_Aires').toLocaleString();
console.log(colors.red('setZone America/Buenos_Aires : ') +  colors.blue(fecha));
let fecha_toISO = local.setZone('America/Buenos_Aires').toISO(DateTime.DATETIME_FULL);
console.log(colors.red('setZone America/Buenos_Aires toISO: ') +  colors.blue(fecha_toISO));

var d = DateTime.fromISO('2014-08-06T13:07:04.054').setLocale('es');
console.log(colors.red('setLocale : ') +  colors.blue(d.toLocaleString(DateTime.DATETIME_FULL)));

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





const fechaManual = '2021-01-22';
const convertida =  DateTime.fromISO(fechaManual+'T13:00:00.00');

console.log(colors.yellow('FECHA :' + fechaManual + ' --> ' + convertida.toSQLDate()  ));
