(function () {
    'use strict';

    requirejs.config({
        baseUrl: 'js/libs',
        paths: {
            'Q': 'q',
            'httpRequester': '../scripts/httpRequester'
        }
    });

    define(['Q', '../scripts/student'], function (Q, student) {
        $('<div/>')
            .append($('<h1/>')
                .text('If deleting students is not working add on 28 row in app.js:')
                .append($('<div/>')
                    .text('res.header(\'Access-Control-Allow-Methods\', \'DELETE\');')))
            .appendTo('body')
            .fadeOut(7000);
        //Attaching event on the button to add new students
        $('#addStudent')
            .on('click', function () {
                var name = $('#student-name').val(),
                    grade = $('#student-grade').val();
                student.add({name: name, grade: parseInt(grade)})
                    .then(function () {
                        student.load();
                    });
            });

        student.load();
    });
}());