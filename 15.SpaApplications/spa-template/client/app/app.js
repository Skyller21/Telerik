(function () {
    'use strict';

    function config($routeProvider) {

        var PARTIALS_PREFIX = 'views/partials/';
        var CONTROLLER_AS_VIEW_MODEL = 'vm';

        // Toastr settings
        toastr.options.showMethod = 'slideDown';
        toastr.options.closeButton = true;
        toastr.options.hideMethod = 'slideUp';
        toastr.options.closeMethod = 'slideUp';
        toastr.options.preventDuplicates = true;
        toastr.options.timeOut = 3000;
        toastr.options.progressBar = true;

        // Route resolvers
        var routeResolvers = {
            authenticationRequired: {
                authenticate: ['$q', 'auth', function ($q, auth) {
                    return auth.isAuthenticated();
                }]
            }
        }

        $routeProvider
            .when('/', {
                templateUrl: PARTIALS_PREFIX + 'home/home.html',
                controller: 'HomeController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/unauthorized', {
                template: '<h1 class="text-center">YOU ARE NOT AUTHORIZED!</h1>'
            })
            .when('/trips', {
                templateUrl: PARTIALS_PREFIX + 'trips/all-trips.html',
                controller: 'TripsController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/trips/create', {
                templateUrl: PARTIALS_PREFIX + 'trips/create-trip.html',
                controller: 'CreateTripController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL,
                resolve: routeResolvers.authenticationRequired
            })
            .when('/trips/details/:id/:name', {
                templateUrl: PARTIALS_PREFIX + 'trips/trip-details.html',
                controller: 'TripDetailsController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/register', {
                templateUrl: PARTIALS_PREFIX + 'identity/register.html',
                controller: 'SignUpCtrl',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/drivers', {
                templateUrl: PARTIALS_PREFIX + 'drivers/drivers.html',
                controller: 'DriversController',
                controllerAs: 'vm'
            })
            .when('/drivers/:driverId',{
                templateUrl: PARTIALS_PREFIX + 'drivers/driver-details.html',
                controller: 'DriverDetailsController',
                controllerAs: 'vm'
            })
            .otherwise({
                redirectTo: '/'
            });
    }

    function run($http, $cookies, $rootScope, $location, auth) {
        $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {

            if (rejection === 'not authorized') {
                $location.path('/unauthorized');
            }
        });
    };

    angular.module('myApp.services', []);
    angular.module('myApp.directives', []);
    angular.module('myApp.filters', []);
    angular.module('myApp.controllers', ['myApp.services']);
    angular.module('myApp', ['ngRoute', 'ngCookies', 'kendo.directives', 'myApp.controllers', 'myApp.directives', 'myApp.filters'])
        .config(['$routeProvider', config])
        .run(['$http', '$cookies', '$rootScope', '$location', 'auth', run])
        .value('toastr', toastr)
        .constant('baseServiceUrl', 'http://spa2014.bgcoder.com');
}());
