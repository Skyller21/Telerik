(function(){

  var sammyApp = Sammy('#content', function(){

    this.get('#/', function(){
      this.redirect('#/home')
    });

    this.get('#/home', homeController.all);

    this.get('#/login', usersController.login);

    this.get('#/register', usersController.register);

    this.get('#/logout', usersController.logout);

    this.get('#/todos',todosController.all);

    this.get('#/todos/add', todosController.add);
    //
    //this.get('#/events', eventsController.all);

  });

  $(function(){
    sammyApp.run('#/')


  })
}())