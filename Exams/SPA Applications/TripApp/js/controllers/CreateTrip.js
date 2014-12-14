'use strict';

app.controller('CreateTrip', ['$scope', '$location', 'auth', 'notifier', 'cities', 'trips', function ($scope, $location, auth, notifier, cities, trips) {

    cities.getCities().then(function (citiesList) {
        $scope.citiesList = citiesList;
    });

    $scope.trip = {};

    $scope.addTrip = function (trip) {
        var currentDate = new Date();
        var tripDate = new Date(trip.tripDate);
        if (tripDate < currentDate) {
            notifier.error("Departure date must be in the present!");
            return;
        } else if (trip.from === trip.to) {
            notifier.error("Set different from and to locations!");
            return;
        }

        var tripModel = {
            "From": trip.from,
            "To": trip.to,
            "availableSeats": trip.seats,
            "departureTime": tripDate
        };

        trips.addTrip(tripModel)
            .then(function (success) {
                notifier.success('Trip successfuly added!');
                console.log(success);
                $location.path('/trip-details/' + success.id);
            }, function (error) {
                notifier.error(error.message);
            });
    };
}]);