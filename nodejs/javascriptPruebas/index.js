const prod = require('./data.js')
var colors = require('colors');


console.log("--------------forEach----------------".blue);
prod.forEach(i=>{
    console.log(i.nombre);    
});
// console.log("--------------map----------------".blue);
// prod.map(i=>{
//     console.log(i.nombre.yellow);    
// });

console.log("--------------Uso de Spread operator----------------");

//using spread operator
//const arrayCopy = [...prod];
const array = { ...prod };

// arrayCopy.map(i=>{
//     //i.nombre = {...i, nombre  : i.nombre + "_modificado"};
//     i.nombre =  i.nombre + "_modificado";
// });
arrayCopy[0].id = 20000;

console.log(prod);
console.log(arrayCopy);

//console.log(JSON.stringify(array).green);
