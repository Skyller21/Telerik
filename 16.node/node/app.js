var http = require('http');
var os = require('os');

var port = 1000;
var server = http.createServer(function (req, res) {
    res.writeHead(200, {
        'content-type': 'application/json'
    });

    http.get('http://google.com/index.html', function (googleResponse) {

        googleResponse.on('data', function (data) {
            res.write(data);
            res.write('Hello Node.js again');
        })

        googleResponse.on('end', function () {
            res.end();
        })
    });

});

server.listen(port);
console.log('Sever running!');
