
var colors = require('colors');


const numeros = [1,2,3,4];

console.log("--------------Uso de Spread operator----------------");

//using spread operator to clone array
const arrayCopy = [...numeros];

arrayCopy[0] = 20000;

console.log(numeros);
console.log(arrayCopy);


