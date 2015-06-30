//MODULE PATTERN
var db = (function () {
    var lastID = 0;
    var objects = [];

    function getNextID() {
        return ++lastID;
    }

    return {
        add: function (obj) {
            obj.id = getNextID();
            objects.push(obj);
            return this;
        },
        list: function () {
            //return objects.slice();  //Задължително връщаме копие на масива

            return objects.map(function (obj) {
                return {
                    name: obj.name,
                    id: obj.id
                }
            }).slice();
        }
    };
}());
console.log("MODULE PATTERN");
db.add({name: 'John'}).add({name:'Hohn'});
console.log(db.list());

//Evil hacker
console.log("MODULE PATTERN - EVIL HACKER");
var objs = db.list();
objs.push({name: 'Hacked u'});      //Ако върнем slice() го спираме
objs[0].age = 5                     //Ако напрвим map като по-горе, го спираме

console.log(db.list());


//REVEALING MODULE PATTERN
var db = (function () {
    var lastID = 0;
    var objects = [];

    function getNextID() {
        return ++lastID;
    }

    function addObject(obj) {
        obj.id = getNextID();
        objects.push(obj);
    }

    function listObjects() {

        return objects.slice();  //Задължително връщаме копие на масива

        return objects.map(function (obj) {
            return {
                name: obj.name,
                id: obj.id
            }
        }).slice();
    }

    return {
        add: addObject,
        list: listObjects

    };

}());
console.log("REVEALING MODULE PATTERN");
db.add({name: 'John'});
console.log(db.list());

//Evil hacker
console.log("REVEALING MODULE PATTERN - EVIL HACKER");
db.add = function (obj) {
    console.log("OPAAAA");
};
db.add({name: "PESHO"});  //минифициране на кода

