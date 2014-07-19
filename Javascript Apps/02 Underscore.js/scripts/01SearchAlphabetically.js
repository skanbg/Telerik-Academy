(function () {
    var students = [
            {firstName: 'Alexander', lastName: 'Ivanov', age: 15},
            {firstName: 'Strahil', lastName: 'Bozov', age: 30},
            {firstName: 'Qnko', lastName: 'Petrushev', age: 20},
            {firstName: 'Ivan', lastName: 'Alexandrov', age: 35},
            {firstName: 'Васил', lastName: 'Левски', age: 35}
        ],
        filteredStudents;

    function alphabeticallyFirstName(studentsArray) {
        var filterResult = _.filter(studentsArray, function (student) {
            return student.firstName.toLowerCase() < student.lastName.toLowerCase();
        });

        return filterResult;
    }

    console.log('=====================');
    console.log('The original array: ');
    _.each(students, function (student) {
        console.log(student.firstName + ' ' + student.lastName);
    });

    filteredStudents = alphabeticallyFirstName(students);
    console.log('=====================');
    console.log('After filtering: ');
    _.each(filteredStudents, function (student) {
        console.log(student.firstName + ' ' + student.lastName);
    });
}());