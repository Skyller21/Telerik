(function() {
    'use strict';

    function filterProjects() {
        return {
            restrict: 'A',
            templateUrl: 'views/directives/filter-projects-directive.html'
        }
    }

    angular.module('myApp.directives')
        .directive('filterProjects', [filterProjects]);
}());
