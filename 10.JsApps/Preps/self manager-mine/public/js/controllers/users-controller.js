var usersController = function(){

  function login(context){
    templates.get('login')
      .then(function(template){
        context.$element().html(template());
        if(data.users.current()){
          toastr.error(data.users.current().username + ' already logged in')
          context.redirect('#/')


        }

        if(data.users.current()) {
          $('#login-btn').hide();
          $('#register-btn').hide();
          $('#logout-btn').show();
        }
        else{
          $('#login-btn').show();
          $('#register-btn').show();
          $('#logout-btn').hide();
        }
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

        if(data.users.current()) {
          $('#login-btn').hide();
          $('#register-btn').hide();
          $('#logout-btn').show();
        }
        else{
          $('#login-btn').show();
          $('#register-btn').show();
          $('#logout-btn').hide();
        }

        $('#register-submit').on('click', function(){
          var user = {
            username: $('#username').val(),
            password: $('#password').val()
          };

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

  return{
    login: login,
    register: register,
    logout: logout
  }
}();