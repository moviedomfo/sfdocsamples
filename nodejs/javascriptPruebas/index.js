const prod = require('./data.js')
var colors = require('colors');


console.log("--------------forEach----------------".blue);
prod.forEach(i=>{
    console.log(i.name);    
});
// console.log("--------------map----------------".blue);
// prod.map(i=>{
//     console.log(i.nombre.yellow);    
// });

console.log(colors.cyan("--------------Uso de Spread operator----------------"));

//using spread operator
//const arrayCopy = [...prod];
const arrayCopy = [...prod,  {id: 200 , name:"Cereza"} ];

// arrayCopy.map(i=>{
//     //i.name = {...i, name  : i.name + "_modificado"};
//     i.name =  i.name + "_modificado";
// });
arrayCopy[0].id = 20000;
console.log(colors.cyan("--------------Prod----------------"));
console.log(prod);
console.log(colors.cyan("--------------Prod arrayCopy----------------"));
console.log(arrayCopy);

//console.log(JSON.stringify(array).green);
