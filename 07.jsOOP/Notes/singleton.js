var db = (function () {
    var items = [];
    var db = {
        add: function (obj) {
            items.push(obj);
            return db;
        }
    }

    return {
        get: function () {
            return db;
        }
    }

}());

var add = db.add;
console.log(add('John'));