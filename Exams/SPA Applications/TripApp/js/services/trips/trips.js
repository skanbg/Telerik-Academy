'use strict';

app.factory('trips', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl', function ($http, $q, identity, authorization, baseServiceUrl) {
    var tripsApi = baseServiceUrl + '/api/trips';

    var nullValue = function (value) {
        if (value === '') {
            return undefined;
        }
    };

    var tripsQueryBuilder = function (page, orderBy, orderType, from, to, finished, onlyMine) {
        var output = '';
        var queryDict = [];
        queryDict.push({key: 'page', value: page || 1});
        queryDict.push({key: 'orderBy', value: nullValue(orderBy) || 'seats'});
        queryDict.push({key: 'orderType', value: nullValue(orderType) || 'asc'});
        queryDict.push({key: 'finished', value: nullValue(finished) || true});
        queryDict.push({key: 'onlyMine', value: nullValue(onlyMine) || false});
        if (from && from !== '') {
            queryDict.push({key: 'from', value: from});
        }
        if (to && to !== '') {
            queryDict.push({key: 'to', value: to});
        }

        for (var i = 0; i < queryDict.length; i++) {
            var param = queryDict[i];
            if (output.length > 0) {
                output += '&';
            }

            output += param.key + '=' + param.value;
        }

        if (output.length > 0) {
            output = '?' + output;
        }

        return output;
    };

    return {
        addTrip: function (trip) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.post(tripsApi, trip, { headers: headers })
                .success(function (success) {
                    deferred.resolve(success);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        getTrip: function (tripId) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.get(tripsApi + '/' + tripId, { headers: headers })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        joinTrip: function (tripId) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            console.log(tripsApi + '/' + tripId);
            $http.put(tripsApi + '/' + tripId, {}, { headers: headers })
                .success(function (data) {
                    console.log(data);
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        getPublicTrips: function () {
            var deferred = $q.defer();

            $http.get(tripsApi)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        getPrivateTrips: function (page, orderBy, orderType, from, to, finished, onlyMine) {
            var query = tripsQueryBuilder(page, orderBy, orderType, from, to, finished, onlyMine);

            var deferred = $q.defer();
            console.log(query);

            var headers = authorization.getAuthorizationHeader();
            $http.get(tripsApi + query, { headers: headers })
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