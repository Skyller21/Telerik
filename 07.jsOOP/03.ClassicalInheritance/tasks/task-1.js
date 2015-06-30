/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error 		
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {
	var Person = (function () {

        function isNameValid(name){
            if(typeof (name) !='string' || !name.match(/^[A-Za-z]{3,20}$/)){
                throw new Error('The name must be between 3 and 20 symbols');
            }
        }

        function isAgeValid(age){
            if(isNaN(age)){
                throw new Error('The age must be a number');
            }
            if(+age<0||+age>150){
                throw new Error('The age must be in the range [0,150]');
            }
        }

        function processFullName(fullname){
            var arrName = fullname.split(/\s+/);
            isNameValid(arrName[0]);
            isNameValid(arrName[1]);
            return arrName;
        }

		function Person(firstname, lastname, age) {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
		}

        Object.defineProperty(Person.prototype,'firstname',{
            get: function(){
                return this._firstname;
            },
            set: function(value){
                isNameValid(value);
                this._firstname = value;
                return this;
            }
        });

        Object.defineProperty(Person.prototype,'lastname',{
            get: function(){
                return this._lastname;
            },
            set: function(value){
               isNameValid(value);
                this._lastname = value;
                return this;
            }
        });

        Object.defineProperty(Person.prototype,'age',{
            get: function(){
                return this._age;
            },
            set: function(value){
                isAgeValid(value);
                this._age = value;
                return this;
            }
        });

        Object.defineProperty(Person.prototype,'fullname',{
            get: function(){
                return this._firstname + ' ' + this._lastname;
            },
            set: function(value){
                var arrName = processFullName(value);
                this._firstName = arrName[0];
                this._lastname = arrName[1];
                return this;
            }
        });

        Person.prototype.introduce = function() {
            return 'Hello! My name is ' + this._firstname + ' ' + this._lastname + ' and I am ' + this._age + '-years-old';
        };

		return Person;
	} ());

    return Person;
}

module.exports = solve;