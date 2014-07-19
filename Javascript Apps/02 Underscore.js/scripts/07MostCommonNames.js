(function () {
    var peoplesRegister = [
            {firstName: 'Anelia', lastName: 'Ivanova'},
            {firstName: 'Ivan', lastName: 'Ivanov'},
            {firstName: 'Stilian', lastName: 'Petrov'},
            {firstName: 'Krystio', lastName: 'Georgiev'},
            {firstName: 'Ivanina', lastName: 'Georgieva'},
            {firstName: 'Georgi', lastName: 'Georgiev'},
            {firstName: 'Ivan', lastName: 'Petrov'},
            {firstName: 'Krasimir', lastName: 'Georgiev'},
            {firstName: 'Stancho', lastName: 'Karastanchev'},
            {firstName: 'Petyr', lastName: 'Petrov'},
            {firstName: 'Ivan', lastName: 'Georgiev'}
        ],
        mostCommonFirstName,
        mostCommonLastName;

    function getMostCommonFirstName(people) {
        var mostCommon = _.chain(people)
            .groupBy(function (person) {
                return person.firstName;
            })
            .max(function (nameGroup) {
                return nameGroup.length;
            });

        return mostCommon.value().pop().firstName;
    }

    function getMostCommonLastName(people) {
        var mostCommon = _.chain(people)
            .groupBy(function (person) {
                return person.lastName;
            })
            .max(function (nameGroup) {
                return nameGroup.length;
            });

        return mostCommon.value().pop().lastName;
    }

    console.log('=====================');
    console.log('The original array: ');
    console.dir(peoplesRegister);

    mostCommonFirstName = getMostCommonFirstName(peoplesRegister);
    console.log('=====================');
    console.log('Most common first name is: ');
    console.dir(mostCommonFirstName);

    mostCommonLastName = getMostCommonLastName(peoplesRegister);
    console.log('=====================');
    console.log('Most common last name is: ');
    console.dir(mostCommonLastName);
}());