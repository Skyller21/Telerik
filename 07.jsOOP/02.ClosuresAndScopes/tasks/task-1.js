/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
    var library = (function () {
        var books = [];
        var categories = [];
        //var book = {};
        function listBooks() {
            if (arguments.length > 0) {
                if (arguments[0]['category']) {
                    if (categories[arguments[0]['category']])
                        return categories[arguments[0]['category']].books.sort(function (a, b) {
                            return a.ID - b.ID;
                        });
                    return [];
                }

                if (arguments[0]['author']) {
                    if (categories[arguments[0]['author']])
                        return categories[arguments[0]['author']].books.sort(function (a, b) {
                            return a.ID - b.ID;
                        });
                    return [];
                }
            }

            return books;
        }

        function addBook(book) {
            book.ID = books.length + 1;

            if (book['category'].length < 2 || book['category'].length > 100) {
                throw 'Error';
            }
            if (book['title'].length < 2 || book['title'].length > 100) {
                throw 'Error';
            }
            if (!book['author']) {
                throw 'Error'
            }
            for (var obj in books) {
                if (book['isbn'] == books[obj]['isbn']) {
                    throw "error";
                }
                if (book['title'] == books[obj]['title']) {
                    throw "error";
                }
            }

            var regex = /^\d{10}|\d{13}$/;
            if (!book['isbn'].match(regex)) {
                throw 'Error'
            }

            if (categories.indexOf(book['category']) < 0) {
                categories[book['category']] =
                {
                    ID: 1,
                    books: [book]
                };
            } else {
                categories[book['category']]['ID'] = categories.length + 1;
                categories[book['category']]['books'].push(book);
            }
            books.push(book);
            return book;
        }

        function listCategories() {
            var categoryArray = [];
            for (var cat in categories) {
                categoryArray.push(cat)
            }
            return categoryArray;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    }());
    return library;


}
module.exports = solve;
