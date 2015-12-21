(function () {
    'use strict';

    function CreateTripController($location, cities, trips, notifier) {
        var vm = this;

        cities.getAll()
            .then(function (allCities) {
                vm.cities = allCities;
            });

        vm.createTrip = function (newTrip) {
            trips.createTrip(newTrip)
                .then(function (createdTrip) {
                    notifier.success(createdTrip.id + ' created!')
                    $location.path('/trips/details/' + createdTrip.id);
                },
                function(err){
                    notifier.error(err);
                }
            );
        }
    }

    angular.module('myApp.controllers')
        .controller('CreateTripController', ['$location', 'cities', 'trips','notifier', CreateTripController]);
}());
