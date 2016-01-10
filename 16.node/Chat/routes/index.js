'use strict';

let fs = require('fs');

module.exports = function (app) {

  fs.readdir(__dirname, function (err, files) {

    if (err) {
      throw new Error();
    }

    files.filter(f => f.indexOf('-router') > 0)
      .forEach(f => require(__dirname + '/' + f)(app));
  });
};
