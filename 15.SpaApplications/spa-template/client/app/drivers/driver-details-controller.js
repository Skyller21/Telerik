(function () {
    'use strict';

    function DriverDetailsController($routeParams, drivers, identity) {
        debugger;
        var vm = this;
        vm.identity = identity;
        vm.id = $routeParams.driverId;
        
        drivers.driverDetails(vm.id)
            .then(function (driver) {
                vm.driver = driver;
            });

    }

    angular.module('myApp.controllers')
        .controller('DriverDetailsController', ['$routeParams', 'drivers', 'identity', DriverDetailsController])
}());
