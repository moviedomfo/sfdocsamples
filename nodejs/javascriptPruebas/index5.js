
const fetch = require('node-fetch');
var unirest = require("unirest");
const axios = require('axios').default;
var https = require('https');
// const Bluebird = require('bluebird');
// fetch.Promise = Bluebird;
var colors = require('colors');





function call_rapidapi(){

    // var req = unirest("GET", "https://restcountries-v1.p.rapidapi.com/all");
    // req.headers({
    //         "x-rapidapi-key": "4c297f35c7mshb4a17c73baebf7dp1da86fjsne55786fb4afb",
    //         "x-rapidapi-host": "restcountries-v1.p.rapidapi.com",
    //         "useQueryString": true
    //     });

        // req.end(function (res) {
        // 	if (res.error) throw new Error(res.error);

        // 	console.log(res.body);
        // });
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
function getNombre_Axios(){
    axios.defaults.httpAgent = new  https.Agent(
        {
          rejectUnauthorized: false
            
        });
    console.log(colors.blue( 'llamando getNombre_Axios'));
    const url = 'https://localhost:44351/api/Facturas/getByNroFactura?nroFact=297739';
 
    // Make a request for a user with a given ID
axios.get('https://localhost:44351/api/Facturas/getByNroFactura?nroFact=297739')
            .then(function (response) {
              // handle success
                console.log(colors.blue( response));
            })
            .catch(function (error) {
                console.log(colors.red( error));
            
            })
            .then(function () {
            // always executed
            });

   

    
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

//call_rapidapi();
//getNombre_Unirest();
getNombre_Axios();



