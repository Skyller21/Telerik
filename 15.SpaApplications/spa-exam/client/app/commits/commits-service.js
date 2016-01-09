(function () {
    'use strict';

    function commits(data) {
        var COMMITS_URL = 'api/commits';

        function getPublicCommits() {
            return data.get(COMMITS_URL);
        }

        function getCommitById(id) {
            return data.get(COMMITS_URL + '/' + id);
        }

        function latestCommitsByProject(id){
            return data.get(COMMITS_URL + '/byProject/' + id);
        }

        function filterCommits(filters) {
            return data.get(COMMITS_URL + '/all', filters)
        }

        function createCommit(commit) {
            return data.post(COMMITS_URL, commit);
        }

        return {
            getPublicCommits: getPublicCommits,
            getCommitById: getCommitById,
            filterCommits: filterCommits,
            createCommit: createCommit,
            latestCommitsByProject: latestCommitsByProject

        }
    }

    angular.module('myApp.services')
        .factory('commits', ['data', commits])
}());
