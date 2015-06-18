/* Task description */
/*
 Write a function a function that finds all the prime numbers in a range
 1) it should return the prime numbers in an array
 2) it must throw an Error if any on the range params is not convertible to `number`
 3) it must throw an Error if any of the range params is missing
 */
function solve(lower, upper) {

    var arr = [],
        i;
	
	
	
    if (arguments.length != 2) {
        throw 'You should pass lower and upper range boundaries!'
    }
    if (!isNumber(lower) || !isNumber(upper)) {
        throw 'The parameters of the function must be convertible to numbers!'
    }

    for (i = +lower; i <= +upper; i += 1) {
        if (isPrime(i)) {
            arr.push(i);
        }
    }

    return arr;

    //Custom functions

    //Check if convertible to number
    function isNumber(num) {
        return !isNaN(num);
    }

    //Check if number is prime
    function isPrime(num) {
        if(num<2){
            return false;
        }
        if(num===2){
            return true;
        }
        for (var i = 2, len = Math.sqrt(num); i <= len; i += 1) {
            if (num % i === 0) {
                return false;
            }
        }
        return true;
    }
}

module.exports = solve;