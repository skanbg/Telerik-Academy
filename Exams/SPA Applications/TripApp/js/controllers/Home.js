'use strict';

app.controller('Home', ['$scope', '$location', 'auth', 'notifier', 'cities', 'trips', 'statistics', 'identity', 'driversData', function ($scope, $location, auth, notifier, cities, trips, statistics, identity, driversData) {
    $scope.identity = identity;
    $scope.trips = {};
    $scope.trips = {};

    statistics.getStats()
        .then(function (success) {
            $scope.stats = success;
        }, function (error) {
            notifier.error('Something went wrong while loading the statistics!');
        });

    trips.getPublicTrips()
        .then(function (success) {
            $scope.trips = success;
        }, function (error) {
            notifier.error(error);
        });

    driversData.getPublicDrivers()
        .then(function (success) {
            $scope.drivers = success;
        }, function (error) {
            notifier.error('Something went wrong while loading the drivers!');
        });
}]);