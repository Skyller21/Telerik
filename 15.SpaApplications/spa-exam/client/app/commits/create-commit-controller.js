(function () {
    'use strict';

    function CreateCommitController($location, commits, projects, notifier, identity) {
        var vm = this;
        vm.identity = identity;

        vm.allProjects;


        projects.filterProjects({
                'ByUser': identity.getCurrentUser().userName
            })
            .then(function (filteredProjects) {
                vm.allProjects = filteredProjects;
            });


        vm.createCommit = function (newCommit) {
            commits.createCommit(newCommit)
                .then(function (createdCommit) {
                        notifier.success(createdCommit + ' created!')
                        $location.path('/commits');
                        // $location.path('/trips/details/' + createdTrip.id);
                    },
                    function (err) {
                        notifier.error(err);
                    }
                );
        }
    }

    angular.module('myApp.controllers')
        .controller('CreateCommitController', ['$location', 'commits', 'projects', 'notifier', 'identity', CreateCommitController]);
}());
