'use strict';

app.factory('driversData', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl', function ($http, $q, identity, authorization, baseServiceUrl) {
    var driversApi = baseServiceUrl + '/api/drivers';

    return {
        getPublicDrivers: function () {
            var deferred = $q.defer();

            $http.get(driversApi)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        getPrivateDrivers: function (page, nameFilter) {
            page = page || 1;
            nameFilter = nameFilter || '';

            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.get(driversApi + '?page=' + page + '&username=' + nameFilter, { headers: headers })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        getDriver: function (driverId) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.get(driversApi + '/' + driverId, { headers: headers })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }
    }
}]);