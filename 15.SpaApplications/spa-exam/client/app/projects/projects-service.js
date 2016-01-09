(function () {
    'use strict';

    function projects(data) {
        var PROJECTS_URL = 'api/projects';

        function getPublicProjects() {
            return data.get(PROJECTS_URL);
        }

        function getAllProjects() {
            return data.get(PROJECTS_URL + '/all');
        }

        function getProjectById(id) {
            return data.get(PROJECTS_URL + '/' + id);
        }

        function allCollaborators(id) {
            return data.get(PROJECTS_URL + '/collaborators/' + id);
        }

        function filterProjects(filters) {
            return data.get(PROJECTS_URL + '/all', filters)
        }

        function createProject(project) {
            return data.post(PROJECTS_URL, project);
        }

        function addCollaborator(id, user) {
            return data.put(PROJECTS_URL + '/' + id, user);
        }

        return {
            getPublicProjects: getPublicProjects,
            getAllProjects: getAllProjects,
            getProjectById: getProjectById,
            filterProjects: filterProjects,
            createProject: createProject,
            addCollaborator: addCollaborator,
            allCollaborators: allCollaborators
        }
    }

    angular.module('myApp.services')
        .factory('projects', ['data', projects])
}());
