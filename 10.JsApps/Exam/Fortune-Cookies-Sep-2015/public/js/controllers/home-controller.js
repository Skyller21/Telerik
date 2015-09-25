var homeController = function () {

  function all(context) {

    var cookies;

    data.cookies.all()
      .then(function(resCookies) {
        cookies = resCookies.result;

        return templates.get('home');
      })
      .then(function(template) {

        var user = {
          username: localStorage.getItem('STORAGE_USERNAME') || ''
        };
        console.log(cookies);
        utilities.processUserButtons();
        context.$element().html(template({cookies: cookies, currentUser: user}));

      })
  }

  return {
    all: all
  }
}();