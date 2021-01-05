const axios = require('axios').default;
var https = require('https');
const fs = require('fs');
var colors = require('colors');

axios.defaults.httpAgent = new https.Agent ({
    rejectUnauthorized:false
})

function call_Axios_async() {

    console.log(colors.cyan('call_Axios_async'));

//    require('https').globalAgent.options.ca = require('ssl-root-cas/latest').create();
    let url = 'https://localhost:44351/api/Facturas/getByNroFactura?nroFact=297739';
    const axiosConfiguration = {
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
    }
    axios.get(url,axiosConfiguration)
        .then(res => { //esta promesa retorna json
            console.log(colors.blue(res.BusinessData));
        }).catch(function (error) {
            console.log(colors.red(error));
        })
}

call_Axios_async();