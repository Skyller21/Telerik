/* globals module */
function solve() {

  return function (selector, items) {

      var root = document.querySelector(selector);
      root.style.width = '50%'

      var fragment = document.createDocumentFragment();

      var leftDiv = document.createElement('div');

      leftDiv.style.cssText = 'float:left;width:65%;padding:2%;box-sizing:border-box';

        leftDiv.className = 'image-preview'

      var rightDiv = document.createElement('div');



      var filter = document.createElement('div');
      filter.style.textAlign = 'center'
      var input = document.createElement('input');
      input.type = 'text';
      var span = document.createElement('span');
      span.style.display = 'block';
      span.innerHTML = 'Filter';




      filter.appendChild(span);
      filter.appendChild(input);


      rightDiv.style.cssText = 'width:35%;float:left;text-align:center;padding:2%;box-sizing:border-box;height:500px;overflow-y:scroll';
      rightDiv.appendChild(filter);

      var imageContainer = document.createElement('div')
      imageContainer.className = 'images-wrapper'
      rightDiv.appendChild(imageContainer)

      for(var i =0; i<items.length; i++){
            var div = document.createElement('div');
            div.style.width = '100%';
            div.className = 'small-pics image-container'
            var img = document.createElement('img');
            img.src = items[i].url;
            img.style.width='90%'
            var title = document.createElement('span');
            title.innerHTML = items[i].title;
            title.style.display='block'
            div.appendChild(title);
            div.appendChild(img)
            div.style.textAlign = 'center';
            imageContainer.appendChild(div);
      }
      console.log(imageContainer.children.length);
      var bigImage = document.createElement('img');
      var bigTitle = document.createElement('h1');
      bigTitle.style.textAlign = 'center'
      bigTitle.innerHTML = items[0].title;
      bigImage.src = items[0].url
      bigImage.style.width='100%'

      leftDiv.appendChild(bigTitle);
      leftDiv.appendChild(bigImage)


      fragment.appendChild(leftDiv);
      fragment.appendChild(rightDiv);


      imageContainer.addEventListener('click', function(ev){
          var target = ev.target;
          if(target.className.indexOf('small-pics')<0) {
              target = target.parentNode;
              bigTitle.innerHTML =  target.querySelector('span').innerHTML;
              bigImage.src = target.querySelector('img').src;
          }
      },false)



      imageContainer.addEventListener('mouseover', function(ev){
          var target = ev.target;
          if(target.className.indexOf('small-pics')<0) {
              target = target.parentNode;
              target.style.backgroundColor = 'pink'
              target.style.cursor = 'pointer'
          }
      },false)

      imageContainer.addEventListener('mouseout', function(ev){
          var target = ev.target;
          if(target.className.indexOf('small-pics')<0) {
              target = target.parentNode;
              target.style.backgroundColor = ''
          }
      },false)

      filter.addEventListener('keyup', function(ev){
          var target = ev.target;
          for(var i=0; i<imageContainer.children.length;i++){
              var child = imageContainer.children[i];
              if(child.firstChild.innerHTML.toLowerCase().indexOf(target.value.toLowerCase())>=0){
              child.style.display = 'block'
              }
              else{
                  child.style.display = 'none'
              }
          }

      }, false)

      root.appendChild(fragment)


  };
}

module.exports = solve;