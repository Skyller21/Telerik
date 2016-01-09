(function () {
    'use strict';

    function ProjectsController(projects, identity, licenses) {
        var vm = this;
        vm.identity = identity;
        vm.visible = false;
        vm.request = {
            page: 1
        };

        vm.showHideFilters = function () {
            vm.visible = !vm.visible;
        }

        vm.prevPage = function () {
            if (vm.request.page == 1) {
                return;
            }

            vm.request.page--;
            vm.filterProjects();
        }

        vm.nextPage = function () {
            if (!vm.projects || vm.projects.length == 0) {
                return;
            }

            vm.request.page++;
            vm.filterProjects();
        }

        vm.filterProjects = function () {
            projects.filterProjects(vm.request)
                .then(function (filteredProjects) {
                    vm.projects = filteredProjects;
                });
        }

        projects.getPublicProjects()
            .then(function (publicProjects) {
                vm.projects = publicProjects;
            });


        projects.getAllProjects()
            .then(function (publicProjects) {
                vm.allProjects = publicProjects;
            });


        licenses.getAll()
            .then(function (allLicenses) {
                vm.licenses = allLicenses;
            });
    }

    angular.module('myApp.controllers')
        .controller('ProjectsController', ['projects', 'identity', 'licenses', ProjectsController]);
}());
