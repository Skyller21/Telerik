'use strict';

var path = require('path');
var rootPath = path.normalize(__dirname + '/../../')

module.exports = {
    development: {
        rootPath: rootPath,
        db: 'mongodb://localhost/telerikgamereviews',
        port: process.env.PORT || 3030
    },
    production: {
        rootPath: rootPath,
        db: 'mongodb://admin:dsadsadsadsadsadsadsaewerwewtewfdfsgfsdfdsfefdsgfdhtrytett@ds027328.mongolab.com:27328/telerikgamereviews',
        port: process.env.PORT || 3030
    }
}
