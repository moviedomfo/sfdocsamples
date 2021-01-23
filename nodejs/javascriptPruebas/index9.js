
var colors = require('colors');

// desestructuración
const product =     { 
    id: 5001, 
    name: "David",
    dni: 243456987,
    email: 'david@gmail.com' 
    };

function test(){

    //aqui desestructuración
    const { name ,email} = product;
    //console.log(colors.blue('product.name : ' + product.name));  
    console.log(colors.blue('nombre : ' + name));  
    console.log(colors.yellow('nombre : ' + email));  
}

const onTest = () =>{

    //aqui desestructuración
    const { name ,email} = product;
    //console.log(colors.blue('product.name : ' + product.name));  
    console.log(colors.blue('nombre : ' + name));  
    console.log(colors.yellow('nombre : ' + email));  
}


onTest();
//test();