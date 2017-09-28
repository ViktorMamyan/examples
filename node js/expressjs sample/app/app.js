var express = require('express');
var app = express();

//root page http://localhost:9999
app.get('/', function(request,response){
    response.send('<h1>OK</h1>');
});

// http://localhost:9999/hello/
app.get('/hello/',function(request,response){
    response.send('<h1>Hello</h1>');
});

// for getting date and time
var d = require('date-and-time');
var now = new Date();

//start server to listen requests
var server = app.listen(9999, function(){
    console.log('OK');

    //get current date and time
    console.log(d.format(now, 'YYYY-MM-DD HH:mm:ss'));
});