
var colors = require('colors');


const numeros = [1,2,3,4,5,6];

console.log("--------------Uso de Spread operator----------------");

//using spread operator to clone array
const arrayCopy = [...numeros];


arrayCopy[0] = 20000;
arrayCopy[4] = 4.5;
console.log(colors.cyan("--------------numeros----------------"));
console.log(numeros);
console.log(colors.cyan("--------------númerod arrayCopy----------------"));
console.log(arrayCopy);
console.log(colors.yellow("*****************************************************"));

// const [num]  =  numeros;

// console.log(num);

