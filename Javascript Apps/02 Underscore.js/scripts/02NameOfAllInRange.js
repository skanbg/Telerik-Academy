(function () {
    var students = [
            {firstName: 'Alexander', lastName: 'Ivanov', age: 60},
            {firstName: 'Strahil', lastName: 'Bozov', age: 19},
            {firstName: 'Qnko', lastName: 'Petrushev', age: 40},
            {firstName: 'Ivan', lastName: 'Alexandrov', age: 20},
            {firstName: 'Васил', lastName: 'Левски', age: 35}
        ],
        filteredStudents;

    function peoplesInRange(studentsArray, min, max) {
        var resultsInRange = _.chain(studentsArray)
            .filter(function (student) {
                return min < student.age && student.age < max;
            })
            .map(function (student) {
                return _.pick(student, ['firstName', 'lastName']);
            });

        return resultsInRange.value();
    }

    console.log('=====================');
    console.log('The original array: ');
    _.each(students, function (student) {
        console.log(student.firstName + ' ' + student.lastName);
    });

    filteredStudents = peoplesInRange(students, 18, 24);
    console.log('=====================');
    console.log('People in age range(only names filtered as said in task): ');
    _.each(filteredStudents, function (student) {
        console.log(student.firstName + ' ' + student.lastName);
    });
}());