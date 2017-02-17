var Promise = require('promise');
var sql = require('mssql');
var cnnString = {
    user: 'sa',
    password: 'as',
    server: 'SANTANA\\SQLEXPRESS2008',
    database: 'celam',

    options: {
        encrypt: true // Use this if you're on Windows Azure 
    }
}

class SociosDAC {

    constructor() {
     
    }





//Ejecuta un query string
    getSocios() {
        return new Promise(function (resolve, reject) {

            var cnn = new sql.Connection(cnnString);
            var req = new sql.Request(cnn);
            req.multiple = true;

            cnn.connect().then(function () {

                req.query('select * from dbo.Socio').then(function (recordset) {

                    resolve(recordset);
                }).catch(err => {
                    reject(new Error('Error en dac' + err.message));
                });

            }).catch(function (err) {
                reject(new Error('Error en dac-cnn' + err.message));
            });
        });
    }

    // Stored Procedure 
    getSociosByParams(id, nombre) {

        return new Promise(function (resolve, reject) {
            sql.connect(cnnString).then(function () {
                // Query 
                new sql.Request()
                    .input('NroSocio', sql.Int, id)
                    .input('NAME', sql.VarChar(10), nombre)
                    .execute('socios_g_params').then(function (recordsets) {
                        resolve(recordsets);
                    }).catch(function (err) {
                        reject(new Error('Error en dac ' + err.message));
                    });


            }).catch(function (err) {
                reject(new Error('Error en dac-cnn ' + err.message));
            });
        });
    }

    
}
module.exports.SociosDAC = SociosDAC;

   //ELOGIN (ConnectionError) - Login failed.
        //ETIMEOUT (ConnectionError) - Connection timeout.
        //EALREADYCONNECTED (ConnectionError) - Database is already connected!
        //EALREADYCONNECTING (ConnectionError) - Already connecting to database!
        //EINSTLOOKUP (ConnectionError) - Instance lookup failed.
        //ESOCKET (ConnectionError) - Socket error.