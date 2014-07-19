(function () {
    var students = [
            {
                firstName: 'Alexander',
                grades: {
                    math: 2,
                    english: 4,
                    biology: 5,
                    physics: 6
                }
            },
            {
                firstName: 'Qnko',
                grades: {
                    math: 6,
                    english: 6,
                    biology: 5,
                    physics: 6
                }
            },
            {
                firstName: 'Ivan',
                grades: {
                    math: 3,
                    english: 3,
                    biology: 5,
                    physics: 6
                }
            },
            {
                firstName: 'Strahil',
                grades: {
                    math: 5,
                    english: 5,
                    biology: 5,
                    physics: 5
                }
            }
        ],
        topStudent;

    function getTopStudent(studentsArray) {
        var resultsInRange = _.max(studentsArray, function (student) {
            return _.reduce(student.grades, function (gradesSum, grade) {
                return gradesSum + grade;
            }, 0);
        });

        return resultsInRange;
    }

    console.log('=====================');
    console.log('The original array: ');
    console.dir(students);

    topStudent = getTopStudent(students);
    console.log('=====================');
    console.log('Student with top grades: ');
    console.log(topStudent.firstName)
}());