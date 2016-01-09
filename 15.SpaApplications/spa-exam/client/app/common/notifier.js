(function () {
    'use strict';

    angular.module('myApp.services').factory('notifier', ['toastr', function (toastr) {
        return {
            success: function (msg) {
                toastr.success(msg);
            },
            error: function (msg) {
                toastr.error(msg);
            },
            warning: function (msg) {
                toastr.warning(msg);
            },
            info    : function (msg) {
                toastr.info(msg);
            }
        }
    }])
}());
