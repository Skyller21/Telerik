'use strict';

let express = require('express'),
  auth = require('./../config/auth'),
  router = new express.Router();

router.post('/login', auth.login)
  .post('/logout', auth.logout);

module.exports = function (server) {
  server.use('/', router);
};
