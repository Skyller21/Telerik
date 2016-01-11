'use strict';

let express = require('express'),
  router = new express.Router();

router.get('/partials/:partialArea/:partialName', function (req, res) {
  res.render('../../public/app/' + req.params.partialArea + '/' + req.params.partialName);
});

router.get('/api/*', function (req, res) {
  res.status(404);
  res.end();
})

router.get('*', function (req, res) {
  res.render('index', {
    currentUser: req.user
  });
});

module.exports = function (server) {
  server.use('/', router);
};
