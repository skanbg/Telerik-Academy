'use strict';

app.controller('SignUpCtrl', ['$scope', '$location', 'auth', 'notifier', function ($scope, $location, auth, notifier) {
    $scope.isDriver = false;

    $scope.signup = function (user) {
        user.isDriver = $scope.isDriver;
        auth.signup(user).then(function () {
            notifier.success('Registration successful!');
            $location.path('/');
        })
    };

    $scope.showCarNameField = function () {
        $scope.isDriver = true;
    };

    $scope.hideCarNameField = function () {
        $scope.isDriver = false;
    };
}]);