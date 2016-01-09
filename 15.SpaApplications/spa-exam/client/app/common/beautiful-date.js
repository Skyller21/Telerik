
(function () {
    'use strict';

    function beautifulDate() {
        return function (input) {
            // check if input is date

            function addZero(i) {
                if (i < 10) {
                    i = "0" + i;
                }
                return i;
            }

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
            var hours = addZero(date.getHours());
            var minutes = addZero(date.getMinutes());
            var seconds = addZero(date.getSeconds());

            // get time

            return day + '/' + monthNames[monthIndex] + '/' + year + ' - ' + hours + ':' + minutes + ':' + seconds;
        }
    }

    angular.module('myApp.filters')
        .filter('beautifulDate', [beautifulDate])
}());
