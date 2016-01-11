'use strict';

module.exports = function (Game) {
  function getAllGames(req, res, next) {
    Game.find({}).exec(function (err, collection) {
      if (err) {
        console.log('Games could not be loaded: ' + err);
      }
      // console.log(collection);
      res.send(collection);
    });
  }

  function getGameById(req, res, next) {
    Game.findOne({
      _id: req.params.id
    }).exec(function (err, game) {
      if (err) {
        console.log('Game could not be loaded: ' + err);
      }

      res.send(game);
    });
  }

  let controller = {
    getAllGames: getAllGames,
    getGameById: getGameById,
  };

  return controller;
};
