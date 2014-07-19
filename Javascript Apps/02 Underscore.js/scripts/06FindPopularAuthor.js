(function () {
    var booksCollection = [
            {name: 'book #1', author: 'Author #1'},
            {name: 'book #2', author: 'Author #2'},
            {name: 'book #3', author: 'Author #2'},
            {name: 'book #4', author: 'Author #1'},
            {name: 'book #5', author: 'Author #3'},
            {name: 'book #6', author: 'Author #3'},
            {name: 'book #7', author: 'Author #1'},
            {name: 'book #8', author: 'Author #3'},
            {name: 'book #9', author: 'Author #3'}
        ],
        mostPopularAuthor;

    function getMostPopularAuthor(booksCollection) {
        var mostPopular = _.chain(booksCollection)
            .groupBy(function (book) {
                return book.author;
            })
            .max(function (authorGroup) {
                return authorGroup.length;
            });

        return mostPopular.value();
    }

    console.log('=====================');
    console.log('The original array: ');
    console.dir(booksCollection);

    mostPopularAuthor = getMostPopularAuthor(booksCollection);
    console.log('=====================');
    console.log('The most popular author is: ');
    console.log(mostPopularAuthor[0].author);
    console.dir(mostPopularAuthor);
}());