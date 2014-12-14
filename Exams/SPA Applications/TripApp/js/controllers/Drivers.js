'use strict';

app.controller('Drivers', ['identity', '$scope', '$location', 'auth', 'notifier', 'cities', 'trips', 'statistics', 'driversData', function (identity, $scope, $location, auth, notifier, cities, trips, statistics, driversData) {
    $scope.identity = identity,
        $scope.pageFilter = 1,
        $scope.sorting = {};

    $scope.$watch(function (scope) {
        return scope.identity.isAuthenticated();
    }, function () {
        loggedActions(identity, $scope);
    });

    function loggedActions(identity, $scope) {
        console.log(identity.isAuthenticated());
        if (identity.isAuthenticated()) {
            authorizedActions($scope);
        } else {
            unauthorizedActions($scope);
        }
    }

    function unauthorizedActions($scope) {
        driversData.getPublicDrivers()
            .then(function (success) {
                $scope.drivers = success;
            }, function (error) {
                notifier.error('Something went wrong while loading the drivers!');
            });
    }

    function authorizedActions($scope) {
        $scope.filterDrivers = function () {
            driversData.getPrivateDrivers($scope.pageFilter, $scope.nameFilter)
                .then(function (success) {
                    $scope.drivers = success;
                }, function (error) {
                    notifier.error('Something went wrong while loading the drivers!');
                });
        };

        $scope.turnPage = function (page) {
            $scope.pageFilter += parseInt(page);
            $scope.pageFilter = $scope.pageFilter == 0 ? 1 : $scope.pageFilter;
            $scope.filterDrivers();
        };

        driversData.getPrivateDrivers()
            .then(function (success) {
                $scope.drivers = success;
            }, function (error) {
                notifier.error('Something went wrong while loading the drivers!');
            });
    }
}]);