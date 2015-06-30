/* Task Description */
/*
* Create an object domElement, that has the following properties and methods:
  * use prototypal inheritance, without function constructors
  * method init() that gets the domElement type
    * i.e. `Object.create(domElement).init('div')`
  * property type that is the type of the domElement
    * a valid type is any non-empty string that contains only Latin letters and digits
  * property innerHTML of type string
    * gets the domElement, parsed as valid HTML
	  * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
  * property content of type string
    * sets the content of the element
    * works only if there are no children
  * property attributes
    * each attribute has name and value
    * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
  * property children
    * each child is a domElement or a string
  * property parent
    * parent is a domElement
  * method appendChild(domElement / string)
    * appends to the end of children list
  * method addAttribute(name, value)
    * throw Error if type is not valid
  * // method removeAttribute(attribute)
*/

function solve() {
	var domElement = (function () {

        //***************HELP FUNCTIONS*****************
        function isValidType(type){
            if(typeof (type) != 'string'
            ||!type.match(/^[A-Za-z0-9]+$/)){
                throw new Error('Not valid type')
            }
        }

        function isValidName(name){
            if(typeof (name) != 'string'
                ||!name.match(/^[A-Za-z0-9-]+$/)){
                throw new Error('Not valid name')
            }
        }

        function sortAttributes(attributes){
            var keys = Object.keys(attributes);
            keys = keys.sort(function(a,b){
                return a.localeCompare(b);
            });
            var arr = [];
            for (var obj in keys) {
                arr[keys[obj]] = attributes[keys[obj]];
            }
            return arr;
        }

        function processAttributes(attributes){
            var result = '';
            if(Object.keys(attributes).length) {
                result += ' ';
                var arrAttributesAsString = [];
                for (var obj in attributes) {
                    arrAttributesAsString.push(obj +'='+ attributes[obj]);
                }
                result+=arrAttributesAsString.join(" ");
            }
            return result;
        }

        function processChildren(children) {
            var result = '';
            for (var obj in children) {
                if (typeof children[obj] === 'string') {
                    result += children[obj];
                } else {
                    result += children[obj].innerHTML;
                }
            }
            return result;
        }

        function processContent(content, children){
            var result = '';
            if(children.length === 0){
                if(!content){
                    result += '';
                }else{
                    result += content;
                }
                result += '';
            }
            return result;
        }

        function resultedInnerHTML(type, attributes, children, content){
            var result = '<' + type;
            result += attributes;
            result += '>';
            result += children;
            result += content;
            result += '</' + type + '>';
            return result;
        }

        //********************DOM ELEMENT CREATION***********************
		var domElement = {
            init: function(type) {
                this.type = type;
                this.children = [];
                this.attributes = [];
                this.parent;
                this.content;
                return this;
            },

            get type() {
                return this._type;
            },

            set type(value){
                isValidType(value);
                this._type = value;
            },

            get content(){
                return this._content;
            },

            set content(value){
                this._content = value;
            },

            get parent(){
                return this._parent;
            },

            set parent(value){
                this._parent = value;
            },

			appendChild: function(child) {
                this.children.push(child);
                if(typeof child === 'object') {
                    child.parent = this;
                }
                return this;
			},

			addAttribute: function(name, value) {
                isValidName(name);
                this.attributes[name] = '"'+value+'"';
                return this;
			},

            removeAttribute: function(attribute){
                var filteredArray = [];
                var isAttributeExist = false;
                for (var obj in this.attributes) {
                    if(obj!=attribute){
                        filteredArray[obj] = this.attributes[obj];
                    }else{
                        isAttributeExist = true;
                    }
                }

                this.attributes = filteredArray;
                if(!isAttributeExist){
                    throw new Error('Non existent attribute')
                }
                return this;
            },

            get innerHTML(){
                var sortedAttributes = sortAttributes(this.attributes);
                var attributes = processAttributes(sortedAttributes);
                var children = processChildren(this.children);
                var content = processContent(this.content, this.children);
                return resultedInnerHTML(this.type, attributes, children, content);
            }
    };
		return domElement;

	} ());




    //******************TESTS******************
    /*var meta = Object.create(domElement)
        .init('meta')
        .addAttribute('charset', 'utf-8');

    var head = Object.create(domElement)
        .init('head')
        .appendChild(meta);

    var div = Object.create(domElement)
        .init('div')
        .addAttribute('style', 'font-size: 42px');

    div.content = 'Hello, world!';

    var body = Object.create(domElement)
        .init('body')
        .appendChild(div)
        .addAttribute('id', 'cuki')
        .addAttribute('bgcolor', '#012345');


    var root = Object.create(domElement)
        .init('html')
        .appendChild(head)
        .appendChild(body);

    console.log(root.innerHTML);*/

    return domElement;

}

solve();

module.exports = solve;
