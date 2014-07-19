(function () {
    var animals = [
            {name: 'cat', legsCount: 2, species: 'mamal'},
            {name: 'human', legsCount: 4, species: 'mamal'},
            {name: 'snake', legsCount: 6, species: 'amphibian'},
            {name: 'frog', legsCount: 8, species: 'amphibian'},
            {name: 'veteran lizard', legsCount: 100, species: 'amphibian'}
        ],
        totalAnimalsLegs;

    function getTotalAnimalsLegsCount(animalsArray) {
        var animalsLegsCount = _.reduce(animalsArray, function (legsCount, animal) {
            return legsCount + animal.legsCount;
        }, 0);

        return animalsLegsCount;
    }

    console.log('=====================');
    console.log('The original array: ');
    console.dir(animals);

    totalAnimalsLegs = getTotalAnimalsLegsCount(animals);
    console.log('=====================');
    console.log('Total animals legs: ');
    console.dir(totalAnimalsLegs)
}());