(function () {
    'use strict';

    requirejs.config({
        baseUrl: 'js/libs',
        paths: {
            'Q': 'q',
            'httpRequester': '../scripts/httpRequester'
        }
    });

    require(['httpRequester', 'Q'], function (httpRequester, Q) {
        var getUrl,
            postUrl,
            getHeaders,
            postHeaders,
            postData;

        //Sending post request.
        postUrl = 'http://localhost:3000/students';
        postHeaders = {'Content-type': 'application/json'};
        postData = JSON.stringify({name: 'Pesho', grade: 2});
        httpRequester.postJSON(postUrl, postHeaders, postData)
            .then(function (data) {
                console.log('POST DATA:');
                console.log(data);
            }, function (error) {
                console.log('POST ERROR:');
                console.warn(error);
            });

        //Sending get request
        getUrl = 'http://localhost:3000/students'; // 'https://api.github.com/users/ivaylokenov';
        getHeaders = {'Content-type': 'application/json'};
        httpRequester.getJSON(getUrl, getHeaders)
            .then(function (data) {
                console.log('GET DATA:');
                console.log(data);
            }, function (error) {
                console.log('GET ERROR:');
                console.warn(error);
            });
    });
}());