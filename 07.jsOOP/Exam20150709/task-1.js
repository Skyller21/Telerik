function solve() {
    var CONSTANTS = {
        MAX_LENGTH: 25,
        MIN_LENGTH: 3,
        MIN_RATING: 1,
        MAX_RATING: 5
    }
    var validator = {
        validateString: function (string, name) {
            if (typeof(string) !== 'string' ||
                string.length < CONSTANTS.MIN_LENGTH ||
                string.length > CONSTANTS.MAX_LENGTH) {
                throw {
                    name: 'Invalid' + name + 'Error',
                    message: 'The ' + name + ' must be string and in the length must be in range ['
                    + CONSTANTS.MIN_LENGTH + ','
                    + CONSTANTS.MAX_LENGTH + ']'
                }
            }
        },

        validateNumber: function (value) {
            if (value === undefined) {
                throw new Error('The value cannot be undefined')
            }
            if (typeof (value) !== 'number') {
                throw new Error('The value must be number')
            }
            if (+value <= 0) {
                throw new Error('The number must be positive')
            }
        },

        validateRating: function (value) {
            if (value === undefined) {
                throw new Error('The value cannot be undefined')
            }
            if (typeof (value) !== 'number') {
                throw new Error('The value must be number')
            }
            if (+value < CONSTANTS.MIN_RATING || +value > CONSTANTS.MAX_RATING) {
                throw new Error('The rating must be between 1 and 5')
            }
        }

    }


    var player = (function () {
        var lastId = 0;
        var player = {
            init: function (name) {
                this.name = name;
                this.id = ++lastId;
                this.playlists = [];
                return this;
            },
            get name() {
                return this._name;
            },
            set name(value) {
                validator.validateString(value);
                this._name = value;
            },
            addPlaylist: function (playlist) {
                if (typeof (playlist) !== 'object' || playlist === undefined || playlist.id === undefined) {
                    throw new Error('Invalid playable or playable id')
                }
                this.playlists.push(playlist);
                return this;
            },
            getPlaylistById: function (id) {
                if (id === undefined || isNaN(id)) {
                    throw new Error('Invalid id to search playlist get')
                }

                for (var obj in this.playlists) {
                    if (this.playlists[obj].id === id) {
                        return this.playlists[obj];
                    }
                }
                return null;
            },
            removePlaylist: function (id) {
                if (id === undefined || isNaN(id)) {
                    throw new Error('Invalid id to search playlist remove ')
                }
                if (id.isPrototypeOf(playlist)) {
                    id = id.id;
                }
                var index = -5;
                for (var i = 0; i < this.playlists.length; i++) {
                    if (this.playlists[i].id === id) {
                        index = i;
                    }
                }
                if (index >= 0) {
                    this.playlists.splice(index, 1);
                }
                return this;
            },
            listPlaylists: function (page, size) {
                if (typeof(page) === 'undefined' ||
                    typeof(size) === 'undefined' ||
                    page < 0 ||
                    size <= 0 ||
                    page * size > this.playlists.length ||
                    isNaN(page) ||
                    isNaN(size)) {
                    throw new Error('invalid page or size');
                }
                if (this.playlists.length > 0) {
                    return this.playlists
                        .slice()
                        .sort(function (p1, p2) {
                            if (p1.title === p2.title) {
                                return p1.id - p2.id;
                            }
                            return p1.name.localeCompare(p2.name);
                        })
                        .splice(page * size, size)
                }
                else {
                    return [];
                }
            },

            search: function (pattern) {
                var playlistsToReturn = [];
                for (var obj in this.playlists) {

                    for (var obj1 in this.playlists[obj].playables) {
                        console.log(this.playlists[obj].playables[obj1]);
                        if (this.playlists[obj].playables[obj1].title.indexOf(pattern) > 0) {
                            playlistsToReturn.push(this.playlists[obj]);
                            break;
                        }
                    }
                }
                return playlistsToReturn;
            }
        }
        return player;
    })()

    var playlist = (function () {
        var lastId = 0;
        var playlist = {
            init: function (name) {
                this.name = name;
                this.id = ++lastId;
                this.playables = [];
                return this;
            },
            get name() {
                return this._name;
            },
            set name(value) {
                validator.validateString(value);
                this._name = value;
            },
            addPlayable: function (playable) {
                if (typeof (playable) !== 'object' || playable === undefined || playable.id === undefined) {
                    throw new Error('Invalid playable or playable id')
                }
                this.playables.push(playable);
                return this;
            },
            getPlayableById: function (id) {
                if (id === undefined || isNaN(id)) {
                    throw new Error('Invalid id to search get playable')
                }

                for (var obj in this.playables) {
                    if (this.playables[obj].id === +id) {
                        return this.playables[obj];
                    }
                }
                return null;
            },
            removePlayable: function (id) {
                console.log(playable.isPrototypeOf(id));
                if (Object.getPrototypeOf(id)==='playable') {

                    throw new Error('Invalid id to search PROTOOOO NOT')
                }
                if (audio.isPrototypeOf(id)) {
                    id = id.id;
                }
                var index = -5;
                for (var i = 0; i < this.playables.length; i++) {
                    if (this.playables[i].id === id) {
                        index = i;
                    }
                }
                if (index >= 0) {
                    this.playables.splice(index, 1);
                }
                else {
                    throw new Error('No such index')
                }
                return this;
            },
            listPlayables: function (page, size) {
                if (typeof(page) === 'undefined' ||
                    typeof(size) === 'undefined' ||
                    page < 0 ||
                    size <= 0 ||
                    page * size > this.playables.length ||
                    isNaN(page) ||
                    isNaN(size)) {
                    throw new Error('invalid page or size');
                }
                if (this.playables.length > 0) {
                    return this.playables
                        .slice()
                        .sort(function (p1, p2) {
                            if (p1.title === p2.title) {
                                return p1.id - p2.id;
                            }
                            return p1.title.localeCompare(p2.title);
                        })
                        .splice(page * size, size)
                }
                else {
                    return [];
                }
            }
        }
        return playlist;
    })()

    var playable = (function () {
        var lastId = 0;
        var playable = {
            init: function (title, author) {
                this.id = ++lastId;
                this.title = title;
                this.author = author;
                return this;
            },
            play: function () {
                return this.id + '. ' + this.title + ' - ' + this.author;
            }
        }

        Object.defineProperty(playable, 'title', {
            get: function () {
                return this._title;
            },
            set: function (newTitle) {
                validator.validateString(newTitle, 'title')
                this._title = newTitle;
            }
        })

        Object.defineProperty(playable, 'author', {
            get: function () {
                return this._author;
            },
            set: function (newTitle) {
                validator.validateString(newTitle, 'author')
                this._author = newTitle;
            }
        })
        return playable;
    })();

    var audio = (function (parent) {
        var audio = Object.create(parent);
        audio.init = function (title, author, length) {
            parent.init.call(this, title, author);
            this.length = length;
            return this;
        }

        audio.play = function (length) {
            parent.play.call(this) + ' - ' + this.length;
        }

        Object.defineProperty(audio, 'length', {
            get: function () {
                return this._length;
            },
            set function (value) {
                validator.validateNumber(value);
                this._length = value;
            }
        })
        return audio;
    })(playable)

    var video = (function (parent) {
        var video = Object.create(parent);
        video.init = function (title, author, imdbRating) {
            parent.init.call(this, title, author);
            this.imdbRating = imdbRating;
            return this;
        }

        video.play = function (imdbRating) {
            parent.play.call(this) + ' - ' + this.imdbRating;
        }

        Object.defineProperty(video, 'imdbRating', {
            get: function () {
                return this._imdbRating;
            },
            set function (value) {
                validator.validateNumber(value);
                this._imdbRating = value;
            }
        })
        return video;
    })(playable)


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
    }
    //var p = module.getAudio('aaaa','aaaaaaa',5);
    //console.log(audio.isPrototypeOf(p));
    return module;

}
solve();
module.exports = solve;
var module = solve();
player = module.getPlayer('pesho');
playlist = module.getPlaylist('gosho');

player.addPlaylist(playlist);
var audio = module.getAudio('ivan', 'ivanov', 4);

playlist.addPlayable(audio);
playlist.removePlayable(1);
var p = module.getAudio('ivan', 'ivanov', 4);

