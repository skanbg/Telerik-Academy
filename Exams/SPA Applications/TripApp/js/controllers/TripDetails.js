'use strict';

app.controller('TripDetails', ['$routeParams', '$scope', '$location', 'auth', 'notifier', 'cities', 'trips', function ($routeParams, $scope, $location, auth, notifier, cities, trips) {

    $scope.trip = {};
    $scope.trip.tripId = $routeParams.tripId;
    trips.getTrip($scope.trip.tripId)
        .then(function (success) {
            $scope.trip = success;
        }, function (error) {
            notifier.error(error);
        });

    $scope.joinTrip = function () {
        trips.joinTrip(this.trip.id)
            .then(function (success) {
                $scope.trip = success;
                notifier.success('Successfuly joined the trip!');
            }, function (error) {
                if (!error || !error.message) {
                    notifier.error('Something went wrong while joining you to the trip!');
                    return;
                }

                notifier.error(error.message);
            });
    };
}]);