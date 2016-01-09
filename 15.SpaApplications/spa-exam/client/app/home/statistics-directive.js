(function() {
    'use strict';

    function allStatistics() {
        return {
            restrict: 'A',
            templateUrl: 'views/directives/statistics-directive.html'
        }
    }

    angular.module('myApp.directives')
        .directive('allStatistics', [allStatistics]);
}());
