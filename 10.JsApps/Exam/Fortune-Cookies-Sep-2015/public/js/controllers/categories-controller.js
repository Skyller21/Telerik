var categoriesController = function(){

  function all(context){
    var categories;

    data.categories.get()
      .then(function(resCategories) {
        categories = resCategories.result;

        return templates.get('categories');
      })
      .then(function(template) {



        var user = {
          username: localStorage.getItem('STORAGE_USERNAME') || ''
        };

    
        context.$element().html(template({categories: categories, currentUser: user}));
        console.log(categories);
        utilities.processUserButtons();



      })


  }



  return {
    all: all
  }
}();
