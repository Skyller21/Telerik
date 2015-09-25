var data = function(){

  /*-----------USERS-----------*/
  function login(user){
    var promise = new Promise(function(resolve, reject){
      var url = 'api/users/auth';
      var reqUser = {
        username: user.username,
        passHash: CryptoJS.SHA1(user.password).toString()
      }
      $.ajax({
        url: url,
        method: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(reqUser),
        success: function(res){
          localStorage.setItem('STORAGE_AUTH_KEY',res.result.authKey);
          localStorage.setItem('STORAGE_USERNAME',res.result.username);
          resolve(res);
        },
        error: function(err){
          reject(err);
        }

      })
    });

    return promise;
  }

  //function register(user){
  //  var promise = new Promise(function(resolve, reject){
  //    var url = 'api/users';
  //      var reqUser = {
  //        username: user.username,
  //        passHash: CryptoJS.SHA1(user.password).toString()
  //      }
  //      $.ajax({
  //        url: url,
  //        method: 'POST',
  //        contentType: 'application/json',
  //        data: JSON.stringify(reqUser),
  //        success: function(res){
  //          localStorage.setItem('STORAGE_AUTH_KEY',res.result.authKey);
  //          localStorage.setItem('STORAGE_USERNAME',res.result.username);
  //          resolve(res);
  //        },
  //        error: function(err){
  //          reject(err);
  //        }
  //      })
  //  });
  //
  //  return promise;
  //}

  function register(user) {
    var reqUser = {
      username: user.username,
      passHash: CryptoJS.SHA1(user.username + user.password).toString()
    };

    return jsonRequester.post('api/users', {
      data: reqUser
    })
      .then(function(resp) {
        var user = resp.result;
        localStorage.setItem('STORAGE_USERNAME', user.username);
        localStorage.setItem('STORAGE_AUTH_KEY', user.authKey);
        return {
          username: resp.result.username
        };
      });
  }

  function logout(){

    var promise = new Promise(function(resolve, reject){
      localStorage.removeItem('STORAGE_USERNAME');
      localStorage.removeItem('STORAGE_AUTH_KEY');
      resolve();

    },function(err){
      reject(err)
    });

    return promise;

  }


  function currentUser(){
    var username = localStorage.getItem('STORAGE_USERNAME');
    var authKey = localStorage.getItem('STORAGE_AUTH_KEY');

    if(authKey){
      var user = {
        username:username,
        authKey: authKey
      }
      return user;
    }else{
      return null;
    }
  }

  /*-----------TODOS-----------*/

  function getTodos(){
    var promise = new Promise(function(resolve, reject){
      var url = 'api/todos';
      var authKey = localStorage.getItem('STORAGE_AUTH_KEY');
      $.ajax({
        url:url,
        method:'GET',
        contentType: 'application/json',
        headers: {
          'x-auth-key':authKey
        },
        success: function(res){
          resolve(res);
        },
        error: function(err){
          reject(err);
        }
      })

    });

    return promise;
  }

  function addTodo(todo){
      var promise = new Promise(function(resolve, reject){

        $.ajax({
          url: 'api/todos',
          method: 'POST',
          contentType: 'application/json',
          data: JSON.stringify(todo),
          headers:{
            'x-auth-key':localStorage.getItem('STORAGE_AUTH_KEY')
          },
          success: function(res){
            resolve(res)
          },
          error: function(err){
            reject(err);
          }
        })
      })

    return promise;
  }

  function updateState(id, state){
    $.ajax({
      url: 'api/todos/' + id,
      method: 'PUT',
      contentType: 'application/json',
      data: JSON.stringify({state: state}),
      headers:{
        'x-auth-key':localStorage.getItem('STORAGE_AUTH_KEY')
      },
      success: function(res){
        resolve(res)
      },
      error: function(err){
        reject(err);
      }

    })
  }


  function categoriesGet(){
    var promise = new Promise(function(resolve, reject){
      var url = 'api/categories';
      var authKey = localStorage.getItem('STORAGE_AUTH_KEY');
      $.ajax({
        url:url,
        method:'GET',
        contentType: 'application/json',
        headers: {
          'x-auth-key':authKey
        },
        success: function(res){
          resolve(res);
        },
        error: function(err){
          reject(err);
        }
      })

    });

    return promise;
  }

  return {
    users:{
      register: register,
      login:login,
      logout: logout,
      current: currentUser
    },
    todos:{
      get: getTodos,
      add: addTodo,
      updateState: updateState
    },
    categories: {
      get: categoriesGet
    }
  }
}();