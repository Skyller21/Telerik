/* globals $ */

/* 

 Create a function that takes an id or DOM element and:

 If an id is provided, select the element
 Finds all elements with class button or content within the provided element
 Change the content of all .button elements with "hide"
 When a .button is clicked:
 Find the topmost .content element, that is before another .button and:
 If the .content is visible:
 Hide the .content
 Change the content of the .button to "show"
 If the .content is hidden:
 Show the .content
 Change the content of the .button to "hide"
 If there isn't a .content element after the clicked .button and before other .button, do nothing
 Throws if:
 The provided DOM element is non-existant
 The id is either not a string or does not select any DOM element


 */

function solve() {
    return function (selector) {

        if (typeof (selector) !== 'string' && selector.nodeType !== 1) {
            throw {
                name: 'InvalidArgumentError',
                message: 'Invalid Argument'
            }
        }


        function getDomElement(selector) {
            var element;
            if (selector.nodeType === 1 && selector.id) {
                element = selector;
                if (!document.body.contains(element)) {
                    throw {
                        name: 'InvalidDomElement',
                        message: 'InvalidDomElement'
                    }
                }
            } else {
                element = document.getElementById(selector);
                if (element == undefined) {
                    throw {
                        name: 'InvalidDomElement',
                        message: 'InvalidDomElement'
                    }
                }
            }

            return element;
        }


        function elementsWithClassButtonHide(element, className) {

            var children = element.childNodes;

            for (var i = 0; i < children.length; i++) {

                if (children[i].className === 'button') {
                    children[i].innerHTML = 'hide';
                }
            }

        }


        var element = getDomElement(selector);
        elementsWithClassButtonHide(element, 'button');

        element.addEventListener('click', function (ev) {
            console.log(ev);
            var target = ev.target;


            if (target.className === 'button') {
                var nextElement = target.nextElementSibling;

                //console.log(nextElement);
                while (nextElement) {
                    //console.log(nextElement);
                    if (nextElement.className === 'content') {
                        if (nextElement.style.display == 'none') {
                            nextElement.style.display = '';
                            target.innerHTML = 'hide';
                            break;
                        }

                        if (nextElement.style.display == '') {
                            nextElement.style.display = 'none';
                            target.innerHTML = 'show';
                            break;
                        }

                    }
                    if (nextElement.className === 'button') {
                        break;
                    }

                    nextElement = nextElement.nextElementSibling;
                }
            }

        }, false)




    };
};

module.exports = solve;