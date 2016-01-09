(function () {
    'use strict';

    function CreateProjectController($location, licenses, projects, notifier) {
        var vm = this;

        licenses.getAll()
            .then(function (allLicenses) {
                vm.licenses = allLicenses;
            });

        vm.createProject = function (newProject) {
            projects.createProject(newProject)
                .then(function (createdProject) {
                    notifier.success(createdProject.id + ' created!')
                    $location.path('/projects');
                    // $location.path('/trips/details/' + createdTrip.id);
                },
                function(err){
                    notifier.error(err);
                }
            );
        }
    }

    angular.module('myApp.controllers')
        .controller('CreateProjectController', ['$location', 'licenses', 'projects','notifier', CreateProjectController]);
}());
