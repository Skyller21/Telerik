app.controller('GameDetailsCtrl', function($scope, $routeParams, cachedGames) {
    //$scope.game = GameResource.get({id: $routeParams.id});
    $scope.game = cachedGames.query().$promise.then(function(collection) {
        collection.forEach(function(game) {
            if (game._id === $routeParams.id) {
                $scope.game = game;
            }
        })
    })
});