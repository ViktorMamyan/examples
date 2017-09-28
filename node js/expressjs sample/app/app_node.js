var http = require('http');

var Server = http.createServer(function(request,response){
    
    response.writeHead(200, {"Content-Type" : "text/plain"});
    response.write('OK');
    response.end();
    //console.log('OK');
});

Server.listen(8899);