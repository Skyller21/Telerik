(function () {
    'use strict';

    function ProjectDetailsController($routeParams, $location, projects, identity, notifier) {
        debugger;
        var vm = this;
        vm.identity = identity;
        vm.id = $routeParams.projectId;


        projects.allCollaborators(vm.id)
            .then(function (collaborators) {
                vm.collaborators = collaborators;
            });

        projects.getProjectById(vm.id)
            .then(function (currentProject) {
                vm.project = currentProject;
            });

        vm.addCollaborator = function () {
            projects.addCollaborator(vm.id, "'" + vm.collaborator + "'")
                .then(function (collaborator) {
                    notifier.success(collaborator + ' added');
                    $location.path('#/projects')
                });
        }

    }

    angular.module('myApp.controllers')
        .controller('ProjectDetailsController', ['$routeParams', '$location', 'projects', 'identity', 'notifier', ProjectDetailsController])
}());
