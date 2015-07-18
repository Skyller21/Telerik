function Solve() {
    var item,
        book,
        media,
        catalog,
        bookCatalog,
        mediaCatalog,
        validator,
        CONSTANTS = {
            TEXT_MIN_LENGTH: 3,
            TEXT_MAX_LENGTH: 25,
            IMDB_MIN_RATING: 1,
            IMDB_MAX_RATING: 5,
            MAX_NUMBER: 9007199254740992
        };

    function objectEquals(obj1, obj2) {
        for (var i in obj1) {
            if (obj1.hasOwnProperty(i)) {
                if (!obj2.hasOwnProperty(i)) return false;
            }
        }
        for (var i in obj2) {
            if (obj2.hasOwnProperty(i)) {
                if (!obj1.hasOwnProperty(i)) return false;
            }
        }
        return true;
    }

    //------------------VALIDATOR---------------------------
    validator = {
        validateIfUndefined: function (val) {

            if (val === undefined) {
                throw new Error('The value cannot be undefined');
            }
        },

        validateString: function (val) {

            this.validateIfUndefined(val);

            if (typeof val !== 'string') {
                throw new Error('The value must be a string');
            }

            if (val.length === 0) {
                throw new Error('The value must be a non-empty string');
            }
        },

        validateStringLength: function (val, minLength, maxLength) {
            if (val.length < minLength || val.length > maxLength) {
                throw new Error('The value must a string with length in interval [' + minLength + ',' + maxLength + ']');
            }
        },

        validateISBN: function (val) {
            var regex = /[^0-9]+/;

            if (val.match(regex)) {
                throw new Error('The isbn must contain only digits');
            }
            if (val.length != 10 && val.length != 13) {
                throw new Error('The isbn must be exactly 10 or 13 symbols long');
            }
        },

        validateIfNumber: function (val) {
            if (typeof val !== 'number') {
                throw new Error('The value must be a number');
            }
        },

        validateRating: function (val) {
            this.validateIfUndefined(val);
            this.validateIfNumber(val);
            if (val < 1 || val > 5) {
                throw new Error('The rating must be between 1 and 5');
            }
        },

        validateDuration: function (val) {
            this.validateIfUndefined(val);
            this.validateIfNumber(val);
            if (val <= 0) {
                throw new Error('The duration must be greater than 0');
            }
        }
    };








    /*------------ITEM--------------*/
    item = (function () {
        var currentItemId = 0;

        var item = Object.create({});

        Object.defineProperty(item, 'init', {
            value: function (description, name) {
                this.description = description;
                this.name = name;
                this._id = ++currentItemId;
                return this;
            },
            enumerable:true
        });

        Object.defineProperty(item, 'id', {
            get: function () {
                return this._id;
            },
            enumerable:true
        });

        Object.defineProperty(item, 'description', {
            get: function () {
                return this._description;
            },
            set: function (val) {
                validator.validateString(val);
                this._description = val;
            },
            enumerable:true
        });

        Object.defineProperty(item, 'name', {
            get: function () {
                return this._name;
            },
            set: function (val) {
                validator.validateString(val);
                validator.validateStringLength(val, 2, 40);
                this._name = val;
            },
            enumerable:true
        });
        return item;
    })();
    /*------------ITEM--------------*/

    /*--------BOOK ITEM---------------*/
    book = (function (parent) {
        var book = Object.create(parent);

        Object.defineProperty(book, 'init', {
            value: function (name, isbn, genre, description) {
                parent.init.call(this, description, name);
                this.isbn = isbn;
                this.genre = genre;
                return this;
            },
            enumerable:true
        });

        Object.defineProperty(book, 'isbn', {
            get: function () {
                return this._isbn;
            },
            set: function (val) {
                validator.validateString(val);
                validator.validateISBN(val);
                this._isbn = val;
            },
            enumerable:true
        });

        Object.defineProperty(book, 'genre', {
            get: function () {
                return this._genre;
            },
            set: function (val) {
                validator.validateString(val);
                validator.validateStringLength(val, 2, 20);
                this._genre = val;
            },
            enumerable:true
        });

        return book;
    })(item);
    /*--------BOOK ITEM---------------*/

    /*--------MEDIA ITEM---------------*/
    media = (function (parent) {
        var media = Object.create(parent);

        Object.defineProperty(media, 'init', {
            value: function (name, rating, duration, description) {
                parent.init.call(this, description, name);
                this.rating = rating;
                this.duration = duration;
                return this;
            }
        });

        Object.defineProperty(media, 'rating', {
            get: function () {
                return this._rating;
            },
            set: function (val) {
                validator.validateRating(val);
                this._rating = val;
            }
        });

        Object.defineProperty(media, 'duration', {
            get: function () {
                return this._duration;
            },
            set: function (val) {
                validator.validateDuration(val);
                this._duration = val;
            }
        });

        return media;
    })(item);
    /*--------MEDIA ITEM---------------*/

    /*---------CATALOG-----------*/
    catalog = (function () {
        var currentCatalogId = 0;
        //var objOfType = {name:"",description:'',id:''};
        var catalog = Object.create({});

        Object.defineProperty(catalog, 'init', {
            value: function (name, items) {
                this.name = name;
                this.items = [];
                this._id = ++currentCatalogId;
                this._objOfType = {name:"",description:'',id:''};
                return this;
            }
        });

        Object.defineProperty(catalog, 'id', {
            get: function () {
                return this._id;
            }

        });

        Object.defineProperty(catalog, 'objOfType', {
            get: function(){
                return this._objOfType;
            },
            enumerable: false

        });

        Object.defineProperty(catalog, 'name', {
            get: function () {
                return this._name;
            },
            set: function (val) {
                validator.validateString(val);
                validator.validateStringLength(val, 2, 40);
                this._name = val;
            }
        });


        //Methods
        Object.defineProperty(catalog, 'add', {

            value: function () {
                console.log(arguments.length);
                var tempArray = [];
                if(arguments===undefined){
                    throw new Error('The arguments must be at least one');
                }
                if (arguments.length == 0) {
                    throw new Error('The arguments must be at least one');
                }
                if (arguments.length === 1) {
                    
                    if (Array.isArray(arguments[0])) {
                        if (arguments[0].length == 0) {
                            throw new Error('The array size cannot be zero');
                        }
                        for (var obj in arguments[0]) {
                            

                            if (!objectEquals(this.objOfType, arguments[0][obj]) && !item.isPrototypeOf(arguments[0][obj])) {
                                throw 'All the items added must be item instances or '
                            }
                            if(objectEquals(this.objOfType, arguments[0][obj])){

                            }
                            tempArray.push(arguments[0][obj]);
                        }
                        if(tempArray.length === arguments[0].length){
                            for (var obj1 in tempArray) {
                                this.items.push(tempArray[obj1]);
                            }
                        }
                    }
                    else {
                        for (var obj3 in arguments[0]) {
                            console.log(arguments[0]);
                            if (!objectEquals(this.objOfType, arguments[0][obj3]) && !item.isPrototypeOf(arguments[0][obj3])) {
                                throw 'All the items added must be item instances or '
                            }
                            tempArray.push(arguments[0][obj]);
                        }

                        if(tempArray.length === arguments[0].length){
                            for (var obj4 in tempArray) {
                                this.items.push(tempArray[obj4]);
                            }
                        }
                        

                    }
                }
                else{

                    for (var obj2 in arguments) {
                        //console.log(objectEquals(objOfType, arguments[obj2]));
                        //console.log(arguments[obj2]);

                        if (!objectEquals(this.objOfType, arguments[obj2]) && !media.isPrototypeOf(arguments[obj2])) {
                            throw 'All the items added must be item instances or '
                        }
                        tempArray.push(arguments[obj2]);
                    }

                    if(tempArray.length===arguments.length){
                        for (var obj1 in tempArray) {
                            this.items.push(tempArray[obj1]);
                        }
                    }
                }


                return this;
            }
        });

        Object.defineProperty(catalog, 'find', {
            value: function (id) {
                var arrOfItems = [];
                validator.validateIfUndefined(id);
                if(typeof(id) ==='object'){
                    for (var obj1 in this.items) {
                        if(this.items[obj1].id === id.id || this.items[obj1].name === id.name){
                            arrOfItems.push(this.items[obj1]);
                        }
                    }
                    return this.items;
                }
                for (var obj in this.items) {
                    if(this.items[obj].id===id){
                        return this.items[obj];
                    }
                }
                return null;
            }


        });

        Object.defineProperty(catalog, 'search', {
            value: function (pattern) {
                var arrOfItems = [];
                validator.validateIfUndefined(pattern);
                for (var obj in this.items) {
                    if(this.items[obj].name.toLowerCase().indexOf(pattern.toLowerCase())>=0||this.items[obj].description.toLowerCase().indexOf(pattern.toLowerCase())>=0){
                        arrOfItems.push(this.items[obj]);
                    }
                }
                return arrOfItems;
            }



        });
        return catalog;
    })();
    /*---------CATALOG-----------*/


    /*------------BOOK CATALOG---------*/

    bookCatalog = (function (parent) {
        var currentCatalogId = 0;
        //var objOfType = {name:'',description:'',isbn:'',genre:'',id:''};

        var bookCatalog = Object.create(parent);


        Object.defineProperty(bookCatalog, 'init', {
            value: function (name, items) {
                parent.init.call(this, name, items);
                this._objOfType = {name:'',description:'',isbn:'',genre:'',id:''};
                return this;
            }


        });

        //Methods
        Object.defineProperty(bookCatalog, 'add', {
            value: function (items) {

                if(Array.isArray(arguments[0])){

                    return parent.add.apply(this,items);
                }
                else{
                    return parent.add.call(this,items);
                }

            }
        });


        Object.defineProperty(bookCatalog, 'getGenres', {
            value: function () {
                var arrGenres = [];

                for (var obj in this.items) {

                    if(arrGenres.indexOf(this.items[obj].genre.toLowerCase())<0){
                        arrGenres.push(this.items[obj].genre.toLowerCase());
                    }
                }

                return arrGenres;
            }


        });

        Object.defineProperty(bookCatalog, 'find', {
            value: function (id) {
                var arrOfItems = [];
                validator.validateIfUndefined(id);
                if(typeof(id) ==='object'){
                    for (var obj1 in this.items) {
                        if(this.items[obj1].id === id.id || this.items[obj1].name === id.name||this.items[obj1].genre === id.genre){
                            arrOfItems.push(this.items[obj1]);
                        }
                    }
                    return this.items;
                }
                for (var obj in this.items) {
                    if(this.items[obj].id===id){
                        return this.items[obj];
                    }
                }
                return null;
            }


        });


        return bookCatalog;
    })(catalog);

    /*------------BOOK CATALOG---------*/

    mediaCatalog = (function (parent) {
        var currentCatalogId = 0;
        //var objOfType = {name:'aaaa', rating:1, duration:3, description:'aaaa',id:'1'};

        var mediaCatalog = Object.create(parent);


        Object.defineProperty(mediaCatalog, 'init', {
            value: function (name, items) {
                parent.init.call(this, name, items);
                this._objOfType = {name:'aaaa', rating:1, duration:3, description:'aaaa',id:'1'};
                return this;
            }


        });

        //Methods
        Object.defineProperty(mediaCatalog, 'add', {

            value: function (items) {
                console.log(arguments);
                if(Array.isArray(arguments[0])){
                    parent.add.apply(this,arguments[0]);
                }
                else{
                    parent.add.call(this,arguments);
                }
                return this;

            }
        });
        Object.defineProperty(mediaCatalog, 'getTop', {
            value: function (count) {
                validator.validateIfUndefined(count);
                validator.validateIfNumber(count);
                if(count<1){
                    throw new Error('')
                }
                
                var arrTop = this.items.sort(function(i1,i2){
                    return i2.rating - i1.rating;
                })

                var len = 0;
                if(count>this.items.length){
                    len = this.items.length;
                }
                else{
                    len = count;
                }
                var arrToReturn = [];
                for(var i = 0; i<len; i++) {
                    var objectToPush = {id:arrTop[i].id,name:arrTop[i].name};
                    arrToReturn.push(objectToPush);
                }
                return arrToReturn;

            }
        });


        Object.defineProperty(mediaCatalog, 'getSortedByDuration', {
            value: function () {

                return this.items.sort(function(m1,m2){
                    if(m1.duration===m2.duration){
                        return m1.id-m2.id;
                    }
                    return m2.duration-m1.duration;
                })

            }
        });


        return mediaCatalog;
    })(catalog);



    return {
        getBook: function (name, isbn, genre, description) {
            return Object.create(book).init(name, isbn, genre, description);
        },
        getMedia: function (name, rating, duration, description) {
            return Object.create(media).init(name, rating, duration, description);
        },
        getBookCatalog: function (name) {
            return Object.create(bookCatalog).init(name);
        },
        getMediaCatalog: function (name) {
            return Object.create(mediaCatalog).init(name);
        }
    };
}

var module = Solve();
var catalog = module.getBookCatalog('John\'s catalog');
var catalogMedia = module.getMediaCatalog('John\'s media');
var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
var m1 = module.getMedia('JavaScript: The Good Parts',3.5,3,"aaa");
var m2 = module.getMedia('JavaScript:',2,1,"aa");
catalogMedia.add(m1,m2);
//catalogMedia.add(m2);
//catalog.add(book1);

//catalog.add({name:"aaaa", isbn:'1111111111', genre:'aaaaa', description:'aaaaa',id:10});

//catalogMedia.add({name:"aaaa", rating:'1111111111', duration:'aaaaa', description:'aaaaa',id:10});
//console.log(catalog.find(book1.id));
////returns book1
////
//console.log(catalog.find({id: book2.id, genre: 'IT'}));
//////returns book2
////
//console.log(catalog.search('js'));
////// returns book2
//
//console.log(catalog.search('javascript'));
////returns book1 and book2
console.log(catalogMedia.getTop(2));
//
//console.log(catalog.search('Te sa zeleni'))
////returns []

