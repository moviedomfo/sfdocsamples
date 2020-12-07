const products = require('./data.js')
var colors = require('colors');



const arrayCopy =  products.map(i=>{
    return {...i, name: i.name + "_modificado"}
});


console.log(products);
console.log(colors.red( arrayCopy));


