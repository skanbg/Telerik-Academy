'use strict';

app.controller('DriverDetails', ['$routeParams', '$scope', '$location', 'auth', 'notifier', 'cities', 'trips', 'statistics', 'driversData', function ($routeParams, $scope, $location, auth, notifier, cities, trips, statistics, driversData) {

    $scope.driverId = $routeParams.driverId,
        $scope.filterCondition = {},
    $scope.predicate = 'driverName';

    driversData.getDriver($scope.driverId)
        .then(function (success) {
            console.log(success);
            $scope.driver = success;
        }, function (error) {
            notifier.error('Something went wrong while loading the drivers!');
        });

    $scope.toggleDriverFilter = function (driverFilter) {
        console.log(driverFilter);
        if (driverFilter.onlyDriver) {
            $scope.filterCondition.driverId = $scope.driverId;
        } else {
            $scope.filterCondition.driverId = null;
        }
    };

    $scope.toggleDriverFilter = function (driverFilter) {
        console.log(driverFilter);
        if (driverFilter.onlyDriver) {
            $scope.filterCondition.driverId = $scope.driverId;
        } else {
            $scope.filterCondition.driverId = null;
        }
    };
}]);