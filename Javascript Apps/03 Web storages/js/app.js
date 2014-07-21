(function () {
    'use strict';

    requirejs.config({
        baseUrl: 'js/libs',
        paths: {
            'jquery': 'jquery',
            'q': 'q',
            'underscore': 'underscore'
        }
    });

    requirejs(["../main"]);
}());