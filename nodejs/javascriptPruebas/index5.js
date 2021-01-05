
const fetch = require('node-fetch');
var unirest = require("unirest");
const axios = require('axios').default;
var https = require('https');
const fs = require('fs');

// const Bluebird = require('bluebird');
// fetch.Promise = Bluebird;
var colors = require('colors');





function call_rapidapi(){

    
    unirest
    .get('https://restcountries-v1.p.rapidapi.com/all')
    .headers({
        "x-rapidapi-key": "4c297f35c7mshb4a17c73baebf7dp1da86fjsne55786fb4afb",
      "x-rapidapi-host": "restcountries-v1.p.rapidapi.com",
      "useQueryString": true})
    //.send({ "parameter": 23, "foo": "bar" })
    .then((response) => {
      console.log(response.body)
    })
  
  
}

async function call_rapidapi_async(){

    console.log(colors.cyan( 'call_rapidapi_async'));
   const response = await unirest
    .get('https://restcountries-v1.p.rapidapi.com/all')
    .headers({
        "x-rapidapi-key": "4c297f35c7mshb4a17c73baebf7dp1da86fjsne55786fb4afb",
      "x-rapidapi-host": "restcountries-v1.p.rapidapi.com",
      "useQueryString": true})    ;
  

      return response;

}
async function call_rapidapi_Axios_async(){

    console.log(colors.cyan( 'call_rapidapi_Axios_async'));
    let url = 'https://restcountries-v1.p.rapidapi.com/all';
    
    let config = {
         headers:{
                "x-rapidapi-key": "4c297f35c7mshb4a17c73baebf7dp1da86fjsne55786fb4afb",
                "x-rapidapi-host": "restcountries-v1.p.rapidapi.com",
                "useQueryString": true
            }
      }

      const response = await axios.get(url,config);
      
        return response;

}



function getNombre_Unirest(){
  
    console.log(colors.blue( 'llamando getNombre_Unirest'));
    const url = 'http://localhost:49701/api/Facturas/getByNroFactura?nroFact=297739';
 
    unirest
        .get(url)
        .headers({
            'Accept': 'application/json', 'Content-Type': 'application/json'  
        })
        .send({ "parameter": 23, "foo": "bar" })
        .then((response) => {
            console.log(colors.blue( response));
                //console.log(colors.blue( response.body));
        })

    
}

function getNombre(nroFact){

    const url = 'http://localhost:49701/api/Facturas/getByNroFactura?nroFact=297739';
 let promise =   fetch(url);

 promise.then(res => {//esta promesa retorna json
                 return res.json()
         })
        .then(json => { // esta muestra el json 

            console.log(colors.blue( json.BusinessData));
        });
    
}




//getNombre(297739);


//getNombre_Unirest();
//getNombre_Axios();

//call_rapidapi();

//Funciona llamada async y store in file
// // var promise = call_rapidapi_async();
// // promise.then((res) =>{
// //     let resToJson = JSON.stringify(res);
// //      fs.writeFileSync('countries.json',resToJson);
     
// //         fs.writeFile('countries-3.json', resToJson, (err) => {
// //             if (err) throw err;
// //             console.log('Data written to file');
// //         });

// //         console.log(colors.italic("se retornaron " + res.length + 'resultados' ));
// // })

///Misma llamada que la anteirir pero con lib Axios
var promise = call_rapidapi_Axios_async();
promise.then(function (res) {
       let resToJson = JSON.stringify(res);
     fs.writeFileSync('countries.json',resToJson);
     
        fs.writeFile('countries-3.json', resToJson, (err) => {
            if (err) throw err;
            console.log('Data written to file');
        });

        console.log(colors.italic("se retornaron " + res.length + 'resultados' ));
  })
  .catch(function (error) {
      console.log(colors.red( error));
  
  })
  .then(function () {
    alert('call_rapidapi_Axios_async');
  });