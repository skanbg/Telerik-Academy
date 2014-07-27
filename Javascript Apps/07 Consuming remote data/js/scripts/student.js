(function () {
    'use strict';

    define(['httpRequester', 'Q', 'jquery'], function (httpRequester, Q, $) {
        var add,
            load,
            deleteByID;

        add = function add(student) {
            var deffered = Q.defer(),
                addURL = 'http://localhost:3000/students',
                stringifiedStudent = JSON.stringify(student);
            httpRequester.postJSON(addURL, {'Content-type': 'application/json'}, stringifiedStudent)
                .then(function (result) {
                    deffered.resolve();
                    $('<h1/>')
                        .text('Student added!')
                        .appendTo('#messages')
                        .fadeOut(3000);
                }, function (error) {
                    deffered.reject();
                    $('<h1/>')
                        .css('color', 'red')
                        .text('Something went wrong while adding the student!')
                        .appendTo('#messages')
                        .fadeOut(3000);
                });

            return deffered.promise;
        };

        deleteByID = function deleteByID(id) {
            var deffered = Q.defer(),
                getURL = 'http://localhost:3000/students/',
                id = parseInt(id);
            httpRequester.deleteJSON(getURL + id + '/', {})
                .then(function (data) {
                    deffered.resolve();
                    $('<h1/>')
                        .text('Student deleted!')
                        .appendTo('#messages')
                        .fadeOut(3000);
                }, function (error) {
                    $.ajax({
                        url: getURL + id + '/',
                        type: "POST",
                        crossDomain: true,
                        data: { _method: 'delete' },
                        dataType: "json",
                        success: function (response) {
                            deffered.resolve();
                        },
                        error: function (xhr, status) {
                            $('<h1/>')
                                .css('color', 'red')
                                .text('Something went wrong while deleting the students!')
                                .appendTo('#messages')
                                .fadeOut(3000);
                        }
                    });
//                    httpRequester.postJSON(, {}, {method: 'delete'})
//                        .then(function () {
//                            deffered.resolve();
//                        }, function () {
//                            deffered.reject();
//                            $('<h1/>')
//                                .css('color', 'red')
//                                .text('Something went wrong while getting the students!')
//                                .appendTo('#messages')
//                                .fadeOut(3000);
//                        });
                });

            return deffered.promise;
        };

        load = function load() {
            var deffered = Q.defer(),
                getURL = 'http://localhost:3000/students';
            httpRequester.getJSON(getURL, [])
                .then(function (data) {
                    deffered.resolve();
                    var objData = JSON.parse(data),
                        students_container = $('#students-list ul'),
                        student,
                        button;
                    students_container.empty();//Deleting children if students are already listed
                    if (objData.count === 0) {
                        $('<h1/>')
                            .text('No students. Add to view updated list.')
                            .appendTo(students_container);
                    }

                    for (var i = 0, len = objData.students.length; i < len; i++) {
                        student = objData.students[i];
                        button = $('<button/>')
                            .text('Delete')
                            .attr('data-id', student.id)
                            .on('click', function () {
                                deleteByID($(this).attr('data-id'))
                                    .then(function () {
                                        load();
                                    });
                            });
                        $('<li/>')
                            .text(student.name + ' - ' + student.grade)
                            .append(button)
                            .appendTo(students_container);
                    }
                }, function (error) {
                    deffered.reject();
                    $('<h1/>')
                        .css('color', 'red')
                        .text('Something went wrong while getting the students!')
                        .appendTo('#messages')
                        .fadeOut(3000);
                });

            return deffered.promise;
        };

        return {
            load: load,
            add: add,
            deleteByID: deleteByID
        }
    });
}());