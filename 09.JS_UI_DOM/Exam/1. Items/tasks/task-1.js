function solve() {
  return function (selector, isCaseSensitive) {

      isCaseSensitive = isCaseSensitive||false;

      var root = document.querySelector(selector);
      root.style.width = '20%'


      var addDiv = document.createElement('div');
      addDiv.className = 'add-controls';

      var resultDiv = document.createElement('div');
      resultDiv.className = 'result-controls';

      var searchDiv = document.createElement('div');
      searchDiv.className = 'search-controls';


      var text = document.createElement('label');
      text.innerHTML = 'Enter text';
      var input = document.createElement('input')
      input.type='text';

      var button = document.createElement('div');
      button.className = 'button';
      button.innerHTML = 'Add';
      button.style.cssText = 'background-color:lightgray;text-align:center;padding:7px'
      button.style.display = 'block';
      button.style.width = '100%'


      // ul
      var ul = document.createElement('ul');
      ul.className = 'items-list';
      ul.style.listStyleType = 'none';




      // Add controls
      addDiv.appendChild(text);
      addDiv.appendChild(input);
      addDiv.appendChild(button);


      // result controls
      resultDiv.appendChild(ul);


      //search

      var textSearch = document.createElement('label');
      textSearch.innerHTML = 'Search:'
      var inputSearch = document.createElement('input')
      inputSearch.type='text';
      searchDiv.appendChild(textSearch);
      searchDiv.appendChild(inputSearch);


      // add to root
      root.appendChild(addDiv);
      root.appendChild(resultDiv);
      root.appendChild(searchDiv)



      button.addEventListener('click', function(ev){
          var target= ev.target;

          var li = document.createElement('li');
          li.className = 'list-item'

          var text = document.createTextNode(input.value);
          //
          //if(!input.value){
          //    return;
          //}
          var div = document.createElement('div');
          div.className = 'button';
          div.style.cssText = 'padding:5px;background-color:lightgray'
          div.innerHTML = 'X';
          div.style.display = 'inline-block'
          li.appendChild(div);
          li.appendChild(text);
          ul.appendChild(li);
      })


      ul.addEventListener('click',function(ev){
          var target = ev.target;

          if(target.className === 'button') {
              //console.log(target);
              var removeElement = target.parentNode;

              ul.removeChild(removeElement);
          }


      }, false)



      inputSearch.addEventListener('input', function(ev){
          var target = ev.target;
          //console.log(ul.children.length);
          for(var i=0; i< ul.children.length;i++){
              var child = ul.children[i];

              if(isCaseSensitive){

                  if(child.childNodes[1].nodeValue.indexOf(target.value)>=0){
                      child.style.display = 'block'
                  }
                  else{
                      child.style.display = 'none'
                  }
              }
              else{
                  if(child.childNodes[1].nodeValue.toLowerCase().indexOf(target.value.toLowerCase())>=0){
                      child.style.display = 'block'
                  }
                  else{
                      child.style.display = 'none'
                  }
              }


          }


      })



  };
}

module.exports = solve;