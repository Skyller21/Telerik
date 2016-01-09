(function() {
    'use strict';

    function filterCommits() {
        return {
            restrict: 'A',
            templateUrl: 'views/directives/filter-commits-directive.html'
        }
    }

    angular.module('myApp.directives')
        .directive('filterCommits', [filterCommits]);
}());
