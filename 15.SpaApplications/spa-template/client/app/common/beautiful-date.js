(function () {
    'use strict';

    function beautifulDate() {
        return function (input) {
            // check if input is date

            var monthNames = [
              "Jan",
              "Feb",
              "Mar",
              "Apr",
              "May",
              "Jun",
              "Jul",
              "Aug",
              "Sep",
              "Oct",
              "Nov",
              "Dec"
            ];

            var date = new Date(input);
            var day = date.getDate();
            var monthIndex = date.getMonth();
            var year = date.getFullYear();

            // get time

            return day + ' ' + monthNames[monthIndex] + ' ' + year;
        }
    }

    angular.module('myApp.filters')
        .filter('beautifulDate', [beautifulDate])
}());
