/* 
 Create a function that:
 *   Takes an array of students
 *   Each student has:
 *   `firstName`, `lastName` and `age` properties
 *   Array of decimal numbers representing the marks
 *   **finds** the student with highest average mark (there will be only one)
 *   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   **Use underscore.js for all operations**
 */

function solve() {
    return function (students) {
        var first = _.chain(students)
            .map(function (item) {
                var count = (item.marks.length === 0 ? 1 : item.marks.length)
                    ,avgMark =  _.reduce(item.marks, function (sum, el) {
                        return sum + el;
                    }, 0)

                item.fullName = item.firstName + ' ' + item.lastName;
                item.avgMark = avgMark / count;
                return item;
            })
            .sortBy('avgMark')
            .last()
            .value();

        console.log(first.fullName + ' has an average score of ' + first.avgMark);
    };
}

module.exports = solve;
