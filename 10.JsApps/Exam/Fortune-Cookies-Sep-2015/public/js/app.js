(function(){

  var sammyApp = Sammy('#content', function(){

    this.get('#/', function(){
      this.redirect('#/home')
    });

    this.get('#/home', cookiesController.all);

    this.get('#/login', usersController.login);

    this.get('#/register', usersController.register);

    this.get('#/logout', usersController.logout);

    this.get('#/users',usersController.all);

    //this.get('#/cookies/all', cookiesController.all);
    //
    this.get('#/cookies/add', cookiesController.shareNew);

    this.get('#/cookies/:id', cookiesController.shareNew);

    //this.get('#/cookies?cookies=sortBy=likes', cookiesController.sortCookies);

    this.get('#/categories', categoriesController.all);

    this.get('#/my-cookie', cookiesController.myCookie)



  });

  $(function(){
    sammyApp.run('#/')


  })
}())