'use strict';

let express = require('express'),
  auth = require('./../config/auth'),
  mongoose = require('mongoose'),
  router = new express.Router(),
  User = mongoose.model('User'),
  usersController = require('../controllers/users-controller')(User);

router.get('/', usersController.getAllUsers)
  .post('/', usersController.createUser)
  .put('/', auth.isAuthenticated, usersController.updateUser);

module.exports = function (server) {
  server.use('/api/users', router);
};
