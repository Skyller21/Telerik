(function () {
    'use strict';

    function CommitDetailsController($routeParams, commits, identity) {
        debugger;
        var vm = this;
        vm.identity = identity;
        vm.id = $routeParams.commitId;
        

        commits.getCommitById(vm.id)
            .then(function (currentCommit) {
                vm.commit = currentCommit;
            });


    }

    angular.module('myApp.controllers')
        .controller('CommitDetailsController', ['$routeParams', 'commits', 'identity', CommitDetailsController])
}());
