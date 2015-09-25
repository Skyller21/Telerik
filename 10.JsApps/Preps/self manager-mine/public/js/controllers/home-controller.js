var homeController = function () {

  function all(context) {

    templates.get('home').
      then(function(template){
        var user = {
          username: localStorage.getItem('STORAGE_USERNAME')
        }
        context.$element().html(template(user));
        utilities.processUserButtons();
      })
  }

  return {
    all: all
  }
}();