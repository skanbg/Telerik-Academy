'use strict';

app.controller('TripsList', ['identity', '$routeParams', '$scope', '$location', 'auth', 'notifier', 'cities', 'trips', function (identity, $routeParams, $scope, $location, auth, notifier, cities, trips) {
    $scope.identity = identity;
    $scope.trips = {};

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
        trips.getPublicTrips()
            .then(function (success) {
                $scope.trips = success;
            }, function (error) {
                notifier.error(error.message);
            });
    }

    function authorizedActions($scope) {
        $scope.turnPage = function (page) {
            $scope.filters.page += parseInt(page);
            $scope.filters.page = $scope.filters.page == 0 ? 1 : $scope.filters.page;
            $scope.loadTrips();
        };

        cities.getCities()
            .then(function (success) {
                $scope.citiesList = success;
            }, function (error) {
                notifier.error('Sorry, cant load cities!');
            });

        $scope.filters = {};
        $scope.filters.page = 1;
//        $scope.filters.orderBy = 'asc';
//        $scope.filters.orderType = 1;
//        $scope.filters.finished = 1;
//        $scope.filters.onlyMine = 1;
        $scope.loadTrips = function () {
            trips.getPrivateTrips($scope.filters.page, $scope.filters.orderBy, $scope.filters.orderType, $scope.filters.from, $scope.filters.to, $scope.filters.finished, $scope.filters.onlyMine)
                .then(function (success) {
                    $scope.trips = success;
                }, function (error) {
                    notifier.error(error.message);
                });
        };

        $scope.loadTrips();
    }
}]);