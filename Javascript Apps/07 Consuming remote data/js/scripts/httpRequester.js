(function () {
    'use strict';

    define(['Q'], function (Q) {
        var httpRequester = (function (Q) {
            var getJSON,
                postJSON,
                getHttpRequest,
                utilizeHttpRequest,
                deleteJSON;

            getHttpRequest = (function () {
                var xmlHttpFactories;
                xmlHttpFactories = [
                    function () {
                        return new XMLHttpRequest();
                    }, function () {
                        return new ActiveXObject("Msxml3.XMLHTTP");
                    }, function () {
                        return new ActiveXObject("Msxml2.XMLHTTP.6.0");
                    }, function () {
                        return new ActiveXObject("Msxml2.XMLHTTP.3.0");
                    }, function () {
                        return new ActiveXObject("Msxml2.XMLHTTP");
                    }, function () {
                        return new ActiveXObject("Microsoft.XMLHTTP");
                    }
                ];
                return function () {
                    var xmlFactory, _i, _len;
                    for (_i = 0, _len = xmlHttpFactories.length; _i < _len; _i++) {
                        xmlFactory = xmlHttpFactories[_i];
                        try {
                            return xmlFactory();
                        } catch (_error) {

                        }
                    }
                    return null;
                };
            })();

            utilizeHttpRequest = (function () {
                var open = function open(url, method, headers, data) {
                    var deffered = Q.defer(),
                        httpRequest;
                    httpRequest = getHttpRequest();
                    httpRequest.open(method, url, true);
                    for (var header in headers) {
                        httpRequest.setRequestHeader(header, headers[header]);
                    }

                    httpRequest.onreadystatechange = function () {//Call a function when the state changes.
                        if (httpRequest.readyState == 4) {
                            var statusCode = Math.floor(httpRequest.status / 100);
                            if (statusCode == 2) {
                                deffered.resolve(httpRequest.responseText);
                            } else {
                                console.log('Code: ' + httpRequest.status);
                                deffered.reject('Something went wrong!');
                            }
                        }
                    };

                    httpRequest.send(data);
                    return deffered.promise;
                };

                return{
                    open: open
                }
            }());

            getJSON = function (url, headers) {
                var deffered;
                deffered = Q.defer();
                utilizeHttpRequest.open(url, 'GET', headers)
                    .then(function (result) {
                        deffered.resolve(result)
                    },
                    function (error) {
                        deffered.reject(error);
                    });

                return deffered.promise;
            };

            postJSON = function postJSON(url, headers, data) {
                var deffered = Q.defer();
                utilizeHttpRequest.open(url, 'POST', headers, data)
                    .then(function (result) {
                        deffered.resolve(result)
                    },
                    function (error) {
                        deffered.reject(error);
                    });
                return deffered.promise;
            };

            deleteJSON = function postJSON(url, headers, data) {
                var deffered = Q.defer();
                utilizeHttpRequest.open(url, 'DELETE', headers, data)
                    .then(function (result) {
                        deffered.resolve(result)
                    },
                    function (error) {
                        deffered.reject(error);
                    });
                return deffered.promise;
            };

            return {
                getJSON: getJSON,
                postJSON: postJSON,
                deleteJSON: deleteJSON
            };
        })(Q);

        return httpRequester;
    });
}());