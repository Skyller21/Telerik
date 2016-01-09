(function () {
    'use strict';

    function LatestCommitsController($routeParams, commits, identity) {
        debugger;
        var vm = this;
        vm.identity = identity;
        vm.id = $routeParams.projectId;


        commits.latestCommitsByProject(vm.id)
            .then(function (allCommits) {
                vm.commits = allCommits;
            });


    }

    angular.module('myApp.controllers')
        .controller('LatestCommitsController', ['$routeParams', 'commits', 'identity', LatestCommitsController])
}());
