var usersController = function(){

  function login(context){
    templates.get('login')
      .then(function(template){
        context.$element().html(template());
        if(data.users.current()){
          toastr.error(data.users.current().username + ' already logged in')
          context.redirect('#/')
        }

       utilities.processUserButtons();
        $('#login-submit').on('click', function(){
          var user = {
            username: $('#username').val(),
            password: $('#password').val()
          };

          if(data.users.current()){
            toastr.error(data.users.current().username + ' already logged in')
          }
          else {
            data.users.login(user)
              .then(function () {
                context.redirect('#/')
                toastr.success(user.username + ' logged in')
              })
            .catch(function(err){
                context.redirect('#/login');
                toastr.error(err.responseJSON)
              })
          }

        })
      })
  }

  function register(context){
    templates.get('register')
      .then(function(template){
        context.$element().html(template());

        if(data.users.current()){
          toastr.error(data.users.current().username + ' already logged in')
          context.redirect('#/')
        }

        utilities.processUserButtons();

        $('#register-submit').on('click', function(){
          if(validator.validateLength($('#username').val()) && validator.validateSymbols($('#username').val())){
            var user = {
              username:$('#username').val(),
              password: $('#password').val()
            };
          }else{

            toastr.error("Invalid username");
            this.redirect('#/register')

            return;

          }



          data.users.register(user)
            .then(function(res){
              context.redirect('#/');
              toastr.success(res.result.username + ' registered');
            })
            .catch(function(err){
              console.log(err);
              toastr.error(err.responseJSON);
            })

        })
      })
  }

  function logout(context){
    templates.get('logout')
      .then(function(template){
        context.$element().html(template());
        if(!data.users.current()){
          console.log('Not logged');
          context.redirect('#/');
        }else {
          console.log('Logged');
          var currentUser = data.users.current();
          data.users.logout()
            .then(function (res) {
              console.log(res);
              context.redirect('#/');
              toastr.success(currentUser.username  + ' logged out')
            })
        }

      })
  }

  function all(context){
    var users;

    data.users.all()
      .then(function(resUsers) {
        users = resUsers.result;

        return templates.get('users');
      })
      .then(function(template) {


        //var groups = _.chain(todos)
        //  .groupBy('category')
        //  .map(function(todos, categoryName) {
        //    return {
        //      category: categoryName,
        //      todos: todos
        //    }
        //  })
        //  .filter(function(group) {
        //    if (category) {
        //      return group.category === category;
        //    }
        //    else {
        //      return group;
        //    }
        //  })
        //  .value();

        var user = {
          username: localStorage.getItem('STORAGE_USERNAME') || ''
        };


        context.$element().html(template({users: users, currentUser: user}));
        utilities.processUserButtons();



        


      })
  }

  return{
    login: login,
    register: register,
    logout: logout,
    all: all
  }
}();