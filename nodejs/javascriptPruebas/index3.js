// Uso de map
const products = require('./data.js');
                              
var colors = require('colors');


let listaNombre = products.map(producto =>  producto.name);

products.map(p => 
       console.log('El gusto es ' + p.name)
     );

//console.log(listaNombre);
     
const arrayCopy =  products.map(i=>{
        return {...i, name: i.name + "_modificado"}
    });
    
// console.log(products);
// console.log(colors.red( arrayCopy));


console.log('----------------------SUMAR VECTORES------------------');
const numerosA = [1,2,3,4,5,6];
const numerosB = [100,200,300];

// Este alg es mas largo pero valida Null en numerosB
var result = numerosA.map(Number)
  .map( (item, ix) =>{

       let b = numerosB[ix] ? Number(numerosB[ix])  : 0;
       return item + b;

    } )
  .map( (item) => item.toString() );


//var result =  numerosA.map( (item, ix) => (Number(item) + Number(numerosB[ix])).toString() );

  console.log(result);
  //console.log(result);

