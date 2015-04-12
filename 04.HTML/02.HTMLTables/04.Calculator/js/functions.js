function onClickButton(objectID) {

    var elem = document.getElementById("input");
    if (elem.value.length < 20) {
        if (objectID == "one") {
            elem.value = elem.value + 1;
        } else if (objectID == "two") {
            elem.value = elem.value + 2;
        } else if (objectID == "two") {
            elem.value = elem.value + 2;
        } else if (objectID == "three") {
            elem.value = elem.value + 3;
        } else if (objectID == "four") {
            elem.value = elem.value + 4;
        } else if (objectID == "five") {
            elem.value = elem.value + 5;
        } else if (objectID == "six") {
            elem.value = elem.value + 6;
        } else if (objectID == "seven") {
            elem.value = elem.value + 7;
        } else if (objectID == "eight") {
            elem.value = elem.value + 8;
        } else if (objectID == "nine") {
            elem.value = elem.value + 9;
        } else if (objectID == "zero") {
            elem.value = elem.value + 0;
        } else if (objectID == "plus") {
            elem.value = elem.value + "+";
        } else if (objectID == "minus") {
            elem.value = elem.value + "-";
        } else if (objectID == "multiply") {
            elem.value = elem.value + "*";
        } else if (objectID == "divide") {
            elem.value = elem.value + "/";
        } else if (objectID == "equals") {
            elem.value = eval(elem.value);
        }
    }
    if (objectID == "clear") {
        clearField(elem);
    }
}

function clearField(elem) {
    if (elem.value != "") {
        elem.value = "";
    }
};