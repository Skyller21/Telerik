(function () {
    'use strict';

    function drivers(data) {
        var DRIVERS_URL = 'api/drivers';

        function getPublicDrivers() {
            return data.get(DRIVERS_URL);
        }

        function filterDrivers(filters) {
            return data.get(DRIVERS_URL, filters);
        }

        function driverDetails(driverId){
            return data.get(DRIVERS_URL+'/'+ driverId);
        }

        return {
            getPublicDrivers: getPublicDrivers,
            filterDrivers: filterDrivers,
            driverDetails: driverDetails
        }
    }

    angular.module('myApp.services')
        .factory('drivers', ['data', drivers])
}());
