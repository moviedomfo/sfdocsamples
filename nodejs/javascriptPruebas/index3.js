const productos = require('./data.js')
var colors = require('colors');


let listaNombre = productos.map(producto =>  producto.name);

console.log(listaNombre);

