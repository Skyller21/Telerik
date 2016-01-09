(function () {
    'use strict';

    function CommitsController(commits, identity) {
        var vm = this;
        vm.identity = identity;
        vm.request = {
            page: 1
        };

        vm.filterCommits = function () {
            projects.filterCommits(vm.request)
                .then(function (filteredCommits) {
                    vm.commits = filteredCommits;
                });
        }

        commits.getPublicCommits()
            .then(function (publicCommits) {
                vm.commits = publicCommits;
            });

        // cities.getAll()
        //     .then(function (allCities) {
        //         vm.cities = allCities;
        //     });
    }

    angular.module('myApp.controllers')
        .controller('CommitsController', ['commits', 'identity', CommitsController]);
}());
