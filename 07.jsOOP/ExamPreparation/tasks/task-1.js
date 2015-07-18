function solve() {
    /*--------HELP FUNCTIONS--------*/
    function isStringValid(title, minLength, maxLength) {
        return (typeof (title) === 'string' &&
        title.length >= minLength &&
        title.length <= maxLength);

    }

    if (!Array.prototype.find) {
        Array.prototype.find = function (predicate) {
            if (this == null) {
                throw new TypeError('Array.prototype.find called on null or undefined');
            }
            if (typeof predicate !== 'function') {
                throw new TypeError('predicate must be a function');
            }
            var list = Object(this);
            var length = list.length >>> 0;
            var thisArg = arguments[1];
            var value;

            for (var i = 0; i < length; i++) {
                value = list[i];
                if (predicate.call(thisArg, value, i, list)) {
                    return value;
                }
            }
            return undefined;
        };
    }

    var player = (function () {
        var lastId = 0;
        var player = {
            init: function (name) {
                this.playlists = [];
                this.id = lastId += 1;
                this.name = name;
                return this;

            },
            get name() {
                return this._name;
            },
            set name(value) {
                if (!isStringValid(value, 3, 25)) {
                    throw {
                        name: 'InvalidPlaylistNameError',
                        message: 'Invalid name'
                    }
                }
                this._name = value;
            },
            addPlayer: function (playlist) {
                if (typeof (playlist) === 'undefined') {
                    throw  {
                        name: 'InvalidPlaylist',
                        message: '...'

                    }
                }
                this.playlists.push(playlist);
                return this;
                //if(!this.playables){        //  - lazy loading - по-добре по горния начин, иначе трябва да се проверява навсякъде във всеки метод
                //    //...
                //}
            },
            getPlaylistById: function (id) {
                var i,
                    len;
                for (i = 0, len = this.playlists.length; i < len; i += 1) {
                    if (this.playlists[i].id === id) {
                        return this.playlists[i]
                    }
                }
                return null;
            },
            removePlaylist: function (value) {
                if (typeof (value) === 'undefined') {
                    throw {
                        name: 'InvalidIdError',
                        message: 'Invalid Id'
                    }
                }
                if (typeof (value) !== 'number') {
                    value = value.id;
                }
                else{
                    value =+value;
                }

                var playlistToRemove = this.playlists.find(function (playlist) {
                    return playable.id === value;
                });

                if (playlistToRemove === 'undefined') {
                    throw {
                        name: 'InvalidIdError',
                        message: 'Invalid Id'
                    }
                }
                this.playlists = this.playlists.filter(function(playlist){
                    return playlist.id!==value;
                })
                //this.playlists.splice(this.playlists.indexOf(playlistToRemove), 1); //Test it.If not working rewrite the method!
                return this;
            },
            listPlaylists: function (page, size) {
                var from = page * size;
                if (typeof (page) === 'undefined' ||
                    typeof(size) === 'undefined' ||
                    page < 0 ||
                    size <= 0 ||
                    page * size > this.playlists.length) {
                    throw {
                        name: 'InvalidPageSizeError',
                        message: 'InvalidPageSizeError'
                    }
                }
                var sortedPlayalists = this.playlists.sort(function (p1, p2) {
                    if (p1.title === p2.title) {
                        return p1.id - p2.id;
                    }
                    return p1.title.localeCompare(p2.title);
                })
                return this.playlists.slice(from, from + size);  //Fix it
            },

            search: function (pattern) {
                //return all playlists as [] which contains playable with the pattern provided
                pattern = pattern.toLowerCase();
                return this.playlists.filter(function (playlist) {
                    return playlist.getAllPlayables()
                        .some(function (playable) {
                            return playable.title.toLowerCase()
                                    .indexOf(pattern) >= 0;
                        })
                })
            }
        }
        return player;
    })();

    var playlist = (function () {
        var lastId = 0;
        var playlist = {
            init: function (name) {
                this.playables = [];
                this.id = lastId += 1;
                this.name = name;
                return this;

            },
            get name() {
                return this._name;
            },
            set name(value) {
                if (!isStringValid(value, 3, 25)) {
                    throw {
                        name: 'InvalidPlaylistNameError',
                        message: 'Invalid name'
                    }
                }
                this._name = value;
            },
            getAllPlayables: function() {
                return this.playables.slice();
            },
            addPlayable: function (playable) {
                //if (typeof (playable) === 'undefined' || !playable.title) {
                //    throw  {
                //        name: 'InvalidPlayable',
                //        message: '...'
                //
                //    }
                //}
                //if(arguments.length!=1){
                //    throw new Error();
                //}
                this.playables.push(playable);
                return this;
                //if(!this.playables){        //  - lazy loading - по-добре по горния начин, иначе трябва да се проверява навсякъде във всеки метод
                //    //...
                //}
            },
            getPlayableById: function (id) {
                var i,
                    len;
                for (i = 0, len = this.playables.length; i < len; i += 1) {
                    if (this.playables[i].id === id) {
                        return this.playables[i]
                    }
                }
                return null;
            },
            removePlayable: function (value) {

                if (typeof (value) === 'undefined') {
                    throw {
                        name: 'InvalidIdError',
                        message: 'Invalid Id'
                    }
                }
                if (typeof (value) !== 'number') {
                    value = value.id;
                }
                else{
                    value = +value;
                }

                //var playableToRemove = this.playables.find(function (playable) {
                //    return playable.id === value;
                //});
                //
                //if (playableToRemove === 'undefined') {
                //    throw {
                //        name: 'InvalidIdError',
                //        message: 'Invalid Id'
                //    }
                //}
                this.playables = this.playables.filter(function(playable){
                    return playable.id!=value;
                })
                //this.playables.splice(this.playables.indexOf(playableToRemove), 1); //Test it.If not working rewrite the method!
                //return this;
            },
            listPlayables: function (page, size) {
                var from = page * size;
                if (typeof (page) === 'undefined' ||
                    typeof(size) === 'undefined' ||
                    page < 0 ||
                    size <= 0 ||
                    page * size > this.playables.length) {
                    throw {
                        name: 'InvalidPageSizeError',
                        message: 'InvalidPageSizeError'
                    }
                }
                var sortedPlayables = this.playables.sort(function (p1, p2) {
                    if (p1.title === p2.title) {
                        return p1.id - p2.id;
                    }
                    return p1.title.localeCompare(p2.title);
                })
                return this.playables.slice(from, from + size);  //Fix it
            }
        }
        return playlist;
    })();

    var playable = (function () {
        var lastId = 0;
        var playable = {

            init: function (title, author) {
                this.id = lastId += 1;
                this.title = title;
                this.author = author;
                return this;
            },
            get title() {                //тук не можем да сетваме writable, configurable -> Object.defineProperty

                return this._title;
            },
            set title(value) {
                if (!isStringValid(value, 3, 25)) {
                    throw {
                        name: 'InvalidTitleError',
                        message: 'The title must be string and the length must be in range [3,25]'
                    }
                }
                this._title = value;
            },
            get author() {                //тук не можем да сетваме writable, configurable -> Object.defineProperty

                return this._author;
            },
            set author(value) {
                if (!isStringValid(value, 3, 25)) {
                    throw {
                        name: 'InvalidAuthorError',
                        message: 'The author must be string and the length must be in range [3,25]'
                    }
                }
                this._author = value;
            },

            play: function () {
                return this.id + '. ' + this.title + ' - ' + this.author;
            }
        }
        return playable;

    })();

    var audio = (function (parent) {
        var audio = Object.create(parent);              //Ако не създадем нов обект няма да мине през валидацията
                                                        //Не можем да ползваме get и set по горния начин, защото обекта вече е създаден
                                                        //get space и set space е само при инициализация на обекта
        audio.init = function (title, author, length) {
            parent.init.call(this, title, author);      //използваме init на parent-a
            this.length = length;
            return this;
        };
        audio.play = function () {
            return parent.play.call(this) + ' - ' + this.length;
        };

        Object.defineProperty(audio, 'length', {
            get: function () {
                return this._length;
            },
            set: function (value) {
                value = +value;
                if (value <= 0 || isNaN(value)) {
                    throw {
                        name: 'InvalidLengthError',
                        message: 'The number must be greater then 0'
                    }
                }
                this._length = value;
            }
        })

        return audio;
    })
    (playable);

    var video = (function (parent) {
        var video = Object.create(parent);              //Ако не създадем нов обект няма да мине през валидацията
                                                        //Не можем да ползваме get и set по горния начин, защото обекта вече е създаден
                                                        //get space и set space е само при инициализация на обекта
        video.init = function (title, author, length) {
            parent.init.call(this, title, author);      //използваме init на parent-a
            this.length = length;
            return this;
        };
        video.play = function () {
            return parent.play.call(this) + ' - ' + this.length;
        };

        Object.defineProperty(audio, 'imdbRating', {
            get: function () {
                return this._imdbRating;
            },
            set: function (value) {
                value = +value;
                if (typeof (value) !== 'number' ||
                    value < 1 ||
                    value > 5) {
                    throw {
                        name: 'InvalidLengthError',
                        message: 'The number must be greater then 0'
                    }
                }
                this._imdbRating = value;
            }
        })

        return video;
    })(playable);

    var module = {
        getPlayer: function (name) {
            // returns a new player instance with the provided name
            return Object.create(player).init(name);
        },
        getPlaylist: function (name) {
            //returns a new playlist instance with the provided name
            return Object.create(playlist).init(name);
        },
        getAudio: function (title, author, length) {
            //returns a new audio instance with the provided title, author and length
            return Object.create(audio).init(title, author, length);
        },
        getVideo: function (title, author, imdbRating) {
            //returns a new video instance with the provided title, author and imdbRating
            return Object.create(video).init(title, author, imdbRating);
        }
    };


    return module;
}

module.exports = solve;
var module = solve();
var playlist = module.getPlaylist('Rock');
//var playlist1 = module.getPlaylist('Pop');
//
playlist.addPlayable(module.getAudio('Te sa zeleni 1', 'Keranov', 3.12));
//playlist.removePlayable(1);
console.log(playlist.listPlayables(0,10));
playlist.removePlayable(1);
console.log(playlist.getPlayableById(1));
console.log(playlist.listPlayables(0,10));

//playlist.addPlayable(module.getAudio('Te sa zeleni 2', 'Keranov', 3.12));
//playlist.addPlayable(module.getAudio('Te sa zeleni 3', 'Keranov', 3.12));
//playlist.addPlayable(module.getAudio('Te sa zeleni 4', 'Keranov', 3.12));
//playlist.addPlayable(module.getAudio('Te sa zeleni 5', 'Keranov', 3.12));
//playlist.addPlayable(module.getAudio('Te sa zeleni 6', 'Keranov', 3.12));
//playlist.addPlayable(module.getAudio('Te sa zeleni 7', 'Keranov', 3.12));
//playlist.addPlayable(module.getAudio('Te sa zeleni 8', 'Keranov', 3.12));
//playlist.addPlayable(module.getAudio('Te sa zeleni 9', 'Keranov', 3.12));
//playlist.addPlayable(module.getAudio('Te sa zeleni 10', 'Keranov', 3.12));
//playlist.addPlayable(module.getAudio('Te sa zeleni 11', 'Keranov', 3.12));
//playlist.addPlayable(module.getAudio('Te sa zeleni 12', 'Keranov', 3.12));
////console.log(playlist.listPlayables(-1, 7));
//playlist1.addPlayable(module.getAudio('Te sa cherveni 11', 'Keranov', 3.12));
//playlist1.addPlayable(module.getAudio('Te sa zeleni 12', 'Keranov', 3.12));
//
//var player = module.getPlayer('My Player');
//player.addPlayer(playlist);
//player.addPlayer(playlist1);
//console.log(player.search('cherveni'));
//
