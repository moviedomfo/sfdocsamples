
var colors = require('colors');

function showOK(){
    console.log('Aceptable')
}

function showCancel(){
    console.log('Cancelable')
}

function ask(question,y,n){
    console.log('Inicio de ask');
    const type = typeof y
    console.log('value', y, ' type', type);
    // const res = confirm(question)
    
}

// ask('Seguro ', showOK(),showCancel());

// ask('Seguro ', showOK,showCancel);





function a(){
    console.log('Funcion A')
    function b(){
        
        console.log('Funcion B')
        function c(){
            console.log('Funcion C')

        }
    }
}

a()