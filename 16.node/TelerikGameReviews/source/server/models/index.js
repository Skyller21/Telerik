'use strict';

let fs = require('fs');

let files = fs.readdirSync(__dirname)
  .filter(f => f.indexOf('-model') > 0)
  .forEach(f => require(__dirname + '/' + f));
