/* 
 Create a function that:
 *   **Takes** a collection of books
 *   Each book has propeties `title` and `author`
 **  `author` is an object that has properties `firstName` and `lastName`
 *   **finds** the most popular author (the author with biggest number of books)
 *   **prints** the author to the console
 *	if there is more than one author print them all sorted in ascending order by fullname
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve() {
    return function (books) {
        var booksByAuthor = _.chain(books)
            .map(function (item) {
                item.authorFullname = item.author.firstName + ' ' + item.author.lastName;
                return item;
            }).groupBy('authorFullname')
            .value();

        var authors = _.chain(booksByAuthor)
            .keys()
            .sortBy(function (item) {
                return booksByAuthor[item].length;
            }).groupBy(function (item) {
                return booksByAuthor[item].length;
            })
            .value();

        var index = _.chain(authors)
            .keys()
            .last()
            .value();

        _.chain(authors[index])
            .sortBy()
            .each(function (authors) {
                console.log(authors);
            })
    };
}

module.exports = solve;
