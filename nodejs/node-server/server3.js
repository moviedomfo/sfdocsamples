var express = require('express');
var mongo = require('mongoose');
var dac = require('./server3_metodos.js');

var app = express();

app.get('/buscar', function (req, res,next) {
 
    var sociosDAC = new  dac.SociosDAC();
  
   sociosDAC.getSocios()
   .then(function(result){
        res.send(result);
  }).catch(err => res.send(err.message));
   
   
});


app.get('/buscar/:name', function (req, res,next) {

    var sociosDAC = new  dac.SociosDAC();
 sociosDAC.getSociosByParams(null, req.params.name)
   .then(function(result){
        res.send(result);
   
  }).catch(err => res.send(err.message));
   
   
});


var quotes = [
  { author : 'Audrey Hepburn', text : "Nothing is impossible, the word itself says 'I'm possible'!"},
  { author : 'Walt Disney', text : "You may not realize it when it happens, but a kick in the teeth may be the best thing in the world for you"},
  { author : 'Unknown', text : "Even the greatest was once a beginner. Don't be afraid to take that first step."},
  { author : 'Neale Donald Walsch', text : "You are afraid to die, and you're afraid to live. What a way to exist."}
];
//app.use('/quotes/:user_id', function(req, res, next) {
    app.use('/quotes', function(req, res, next) {
    res.json(quotes);
});
app.get('/quote/random', function(req, res) {
  var id = Math.floor(Math.random() * quotes.length);
  var q = quotes[id];
  res.json(q);
});
app.get('/quote/:id', function(req, res) {
  if(quotes.length <= req.params.id || req.params.id < 0) {
    res.statusCode = 404;
    return res.send('Error 404: No quote found');
  }  
    var q = quotes[req.params.id];
  res.json(q);
});


app.listen(5000);
console.log('Server started');


