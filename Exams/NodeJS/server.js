var express = require('express');
var env = process.env.NODE_ENV || 'development';
var app = express();
var config = require('./server/config/config')[env];
require('./server/config/express')(app, config);
require('./server/config/mongoose')(config);
require('./server/config/passport')();
require('./server/config/routes')(app);
app.listen(config.port);
console.log("Server running on port: " + config.port);

var common = require('./server/config/common');
//var path = common.paths.controllers+'/../server.js';
//
//var fs = require('fs');
//fs.readFile(path, 'utf8', function(err, data) {
//    if (err) throw err;
//    console.log(data)
//});