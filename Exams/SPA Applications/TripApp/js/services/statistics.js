'use strict';

app.factory('statistics', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl', function ($http, $q, identity, authorization, baseServiceUrl) {
    var tripsApi = baseServiceUrl + '/api/stats';

    return {
        getStats: function () {
            var deferred = $q.defer();

            $http.get(tripsApi, { cache: true})
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