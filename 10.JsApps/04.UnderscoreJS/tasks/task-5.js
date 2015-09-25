/* 
 Create a function that:
 *   **Takes** an array of animals
 *   Each animal has propeties `name`, `species` and `legsCount`
 *   **finds** and **prints** the total number of legs to the console in the format:
 *   "Total number of legs: TOTAL_NUMBER_OF_LEGS"
 *   **Use underscore.js for all operations**
 */

function solve() {
    return function (animals) {

        var countOfLegs = _.chain(animals)
            .reduce(function (sum, item) {
                return sum + item.legsCount
            }, 0)
            .value();

        console.log('Total number of legs: ' + countOfLegs);
    };
}

module.exports = solve;
