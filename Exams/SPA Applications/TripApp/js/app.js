'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function ($routeProvider, $q) {
        var routeUserChecks = {
            authenticated: {
                authenticate: function (auth) {
                    return auth.isAuthenticated();
                }
            }
        };

        $routeProvider
            .when('/', {
                templateUrl: 'views/partials/home.html',
                controller: 'Home'
            })
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/trips', {
                templateUrl: 'views/partials/all-trips.html',
                controller: 'TripsList'
            })
            .when('/drivers', {
                templateUrl: 'views/partials/all-drivers.html',
                controller: 'Drivers'
            })
            .when('/drivers/:driverId', {
                templateUrl: 'views/partials/driver-details.html',
                controller: 'DriverDetails',
                resolve: routeUserChecks.authenticated
            })
            .when('/trips/create', {
                templateUrl: 'views/partials/create-trip.html',
                controller: 'CreateTrip',
                resolve: routeUserChecks.authenticated
            })
            .when('/trips/:tripId', {
                templateUrl: 'views/partials/trip-details.html',
                controller: 'TripDetails',
                resolve: routeUserChecks.authenticated
            })
            .when('/not-found', {
                templateUrl: 'views/partials/not-found.html'
            })
            .when('/unauthorized', {
                templateUrl: 'views/partials/unauthorized.html'
            })
            .otherwise({ redirectTo: '/not-found' });
    }])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://spa2014.bgcoder.com');

app.run(function ($rootScope, $location) {
    $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
        if (rejection === 'not authorized') {
            $location.path('/unauthorized');
        }
    })
});