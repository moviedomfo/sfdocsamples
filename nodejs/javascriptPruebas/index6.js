const productos = require('./data.js')
var colors = require('colors');





const  geDatos = () =>{
    console.log(colors.blue( 'llamando geDatos asincrono'));
    return new Promise ((resolve,reject) => {
                if(productos.lengthe!==0){
                    reject (new Error("error provocado"));                    
                }

                else{
                    setTimeout(() => {
                        resolve (productos);
                    }, 4000);
                }
                
        });
 
  //reject
    
}




 async function geDatosAsync  (){

    try {
        const data = await geDatos();
    //console.log(colors.bgYellow( data));
      
    return data;
    } catch (error) {
        console.log(colors.red( error.message));
    }
    
}

// geDatos().then((res)=>{
//     console.log(colors.blue( res));
// }).catch(err=>{
//     console.log(colors.red( err));
// });



//console.log(colors.bgYellow( data));



//Se lo puede llamar de ambas formas
//geDatosAsync();
//o como rpomesa
let d = geDatosAsync();
d.then(res=>{
    console.log(colors.yellow( res));
})
