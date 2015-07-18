var animal = function (name) {

    this.init =  function(name) {
        this.name = (name);
    }

    this.isNameValid = function(value) {
        if (typeof (value) != 'string' || value.length < 5) {
            throw new Error('Invalid name');
        }
    }


};

var dog = Object.create(animal);

