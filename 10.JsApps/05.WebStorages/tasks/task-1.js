
function solve() {

    var game = (function () {
        var game;

        function generateNumber() {

            var number = {one: '', two: '', three: '', four: ''}
            _.chain(number)
                .map(function (item, key, obj) {
                    var digit;
                    if (key === 'one') {
                        digit = (Math.random() * 9 | 0) + 1;
                    } else {
                        digit = (Math.random() * 9 | 0);
                    }

                    while (_.contains(_.values(obj), digit)) {
                        digit = (Math.random() * 9 | 0);
                    }

                    return obj[key] = digit;
                }).value();

            return number;
        }

        game = Object.create({});

        Object.defineProperty(game, 'init', {
            value: function (playerName, endCallback) {
                this.playerName = playerName;
                this.endCallback = endCallback;
                this.players = [];
                this.isStarted = true;
                this.number = generateNumber();
                this.playerGuess = {one:'',two:'',three:'',four:''};
                return this;
            }
        });

        Object.defineProperty(game, 'isStarted', {
            get: function () {
                return this._isStarted;
            },
            set: function (value) {
                this._isStarted = value;
            }
        });

        Object.defineProperty(game, 'number', {
            get: function () {
                return this._number;
            }
        });

        Object.defineProperty(game, 'players', {
            get: function () {
                return this._players;
            },
            set: function (value) {
                this._players = value;
            }
        });


        Object.defineProperty(game, 'guess', {
            value: function (number) {
                this.number = number;
                while(this.isStarted){

                }

                return this;
            }
        });

        Object.defineProperty(game, 'getHighScore', {
            value: function (count) {
                console.log(this.players);
                return this;
            }
        });

        return {
            init: game.init,
            guess: game.guess,
            getHighScore: game.getHighScore

        }
    })();

    return game;
}

var test = solve();
test.init('veshev', function a() {
});
test.guess(4);
test.getHighScore(5);

//module.exports = solve;
