
var dayjs = require('dayjs')
var localeData = require('dayjs/plugin/localeData')
dayjs.extend(localeData)
require('dayjs/locale/es')
// import 'dayjs/locale/de' // ES 2015 

dayjs.locale('es') // use locale globally
dayjs().locale('es').format() // use locale in a specific instance
var colors = require('colors');



var local =  dayjs();


console.log(colors.yellow(local));

console.log(colors.yellow('---------------metodos-----------------'));

console.log(colors.red('toJSON              : ') +  colors.blue(local.toJSON()));
console.log(colors.red('toISOString ISO 8601: ') +  colors.blue(local.toISOString()));

console.log(colors.red('Unix timestamp      : ') +  colors.blue(local.unix()));


//var d = DateTime.fromISO('2014-08-06T13:07:04.054').setLocale('es');
//console.log(colors.red('setLocale : ') +  colors.blue(d.toLocaleString(DateTime.DATETIME_FULL)));

console.log(colors.yellow('---------------meses------------------'));
console.log( colors.blue(dayjs.months()));

console.log(colors.yellow('---------------text date------------------'));
console.log(local.format("dddd, MMMM D YYYY"));
console.log(local.format("YYYY-MM-DD"));

console.log(colors.yellow('---------------Time------------------'));
console.log(local.format("HH:mm:ss"));
console.log(local.format("HH:mm:ss a"));
console.log(local.format("HH:mm"));

// console.log(colors.yellow('---------------ISO 8601------------------'));

// console.log(colors.yellow('---------------------------------'));




