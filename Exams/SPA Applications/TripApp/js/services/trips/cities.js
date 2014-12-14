'use strict';

app.factory('cities', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl', function($http, $q, identity, authorization, baseServiceUrl) {
    var citiesApi = baseServiceUrl + '/api/cities';

    return {
        getCities: function() {
            var deferred = $q.defer();

            $http.get(citiesApi)
                .success(function(data) {
                    deferred.resolve(data);
                }, function(response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }
    }
}]);