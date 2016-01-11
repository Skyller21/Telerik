'use strict';

let express = require('express'),
  mongoose = require('mongoose'),
  auth = require('./../config/auth'),
  router = new express.Router(),
  Game = mongoose.model('Game'),
  gamesController = require('./../controllers/games-controller')(Game);

router.get('/', gamesController.getAllGames)
  .get('/:id', gamesController.getGameById);

module.exports = function (server) {
  server.use('/api/games', router);
};
