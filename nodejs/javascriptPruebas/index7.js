const axios = require('axios').default;
const fetch = require('node-fetch');
var https = require('https');
const fs = require('fs');
var colors = require('colors');

const url = 'https://localhost:5100/api/Facturas/getByNroFactura?nroFact=297739';


function call_fetch_async() {
    process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';
    // fetch('https://github.com/')
    // .then(res => res.text())
    // .then(body => console.log(body));
    //const url = 'https://localhost:5100/api/Facturas/getByNroFactura?nroFact=297739';
    console.log(colors.blue('call_fetch_async '));
    try {
        //let promise = 
        fetch(url, {
                'rejectUnauthorized': false

            })
            .then(res => { //esta promesa retorna json
                //console.log(colors.blue('return  call_fetch_async '));
                return res.json()
            })
            .then(json => { // esta muestra el json 
                console.log(colors.blue(json));
            }).catch(error => console.error(colors.red('Error llamando la api.'), error));
    } catch (e) {
        alert(e);
    }


}


function call_Axios_async1() {

    console.log(colors.cyan('call_Axios_async1'));
    // At request level
    const agent = new https.Agent({
        rejectUnauthorized: false
    });

    axios.get(url, {
            httpsAgent: agent
        })
        .then(res => {
            console.log(colors.blue(res.data));
        }).catch(function (error) {
            console.log(colors.red(error));
        });

    }





function call_Axios_async2() {

    console.log(colors.cyan('call_Axios_async2'));


    const instance = axios.create({
        httpsAgent: new https.Agent({
            rejectUnauthorized: false
        })
    });
    instance.get(url)
        .then(function (response) {
            console.log(colors.blue(JSON.stringify(response.data)));
        })
        .catch(function (error) {
            console.log(error);
        });


}
function call_Axios_async3() {

   
    axios({
            url: url,
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
            responseType: 'json',
            httpsAgent: new https.Agent({
                rejectUnauthorized: false
            })
        })
        .then(response => {console.log(
            colors.blue(response.data));}
            )
        .catch(error => {console.log(colors.red(error));})
}

//all_Axios_async();

//call_Axios_async2();


call_fetch_async();