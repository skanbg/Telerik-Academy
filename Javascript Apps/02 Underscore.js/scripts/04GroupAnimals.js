(function () {
    var animals = [
            {name: 'cat', legsCount: 4, species: 'mamal'},
            {name: 'human', legsCount: 2, species: 'mamal'},
            {name: 'snake', legsCount: 0, species: 'amphibian'},
            {name: 'frog', legsCount: 4, species: 'amphibian'},
            {name: 'veteran lizard', legsCount: 3, species: 'amphibian'},
            {name: 'pigeon from Chernobyl', legsCount: 4, species: 'bird'},
            {name: 'pigeon', legsCount: 2, species: 'bird'}
        ],
        groupedAnimals;

    function getGroupedAnimals(animalsArray) {
        var groupedResult = _.chain(animalsArray)
            .groupBy(function (animal) {
                return animal.species;
            })
            .map(function (animalGroup) {
                return _.sortBy(animalGroup, function (animal) {
                    return animal.legsCount;
                });
            });

        return groupedResult.value();
    }

    console.log('=====================');
    console.log('The original array: ');
    console.dir(animals);

    groupedAnimals = getGroupedAnimals(animals);
    console.log('=====================');
    console.log('Grouped animals: ');
    console.dir(groupedAnimals)
}());