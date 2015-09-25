var data = function(){

  /*-----------USERS-----------*/
  function login(user){
    var promise = new Promise(function(resolve, reject){
      var url = 'api/auth';
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

  function register(user){
    var promise = new Promise(function(resolve, reject){
      var url = 'api/users';
        var reqUser = {
          username: user.username,
          passHash: CryptoJS.SHA1(user.password).toString()
        }
        $.ajax({
          url: url,
          method: 'POST',
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


  function getAllUsers(){
      var promise = new Promise(function(resolve, reject){
        var url = 'api/users';
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


  /*-----------COOKIES-----------*/



  function getCookies(){
    var promise = new Promise(function(resolve, reject){
      var url = 'api/cookies';
      var authKey = localStorage.getItem('STORAGE_AUTH_KEY');
      $.ajax({
        url:url,
        method:'GET',
        contentType: 'application/json',

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

  function shareCookie(cookie){
      var promise = new Promise(function(resolve, reject){

        $.ajax({
          url: 'api/cookies',
          method: 'POST',
          contentType: 'application/json',
          data: JSON.stringify(cookie),
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

  function update(id, action){
    var promise = new Promise(function(resolve, reject) {
      $.ajax({
        url: 'api/cookies/' + id,
        method: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify({type: action}),
        headers: {
          'x-auth-key': localStorage.getItem('STORAGE_AUTH_KEY')
        },
        success: function(res) {
          resolve(res)
        },
        error: function(err) {
          reject(err);
        }

      })
    })

    return promise;
  }


  function myCookie(){
    var promise = new Promise(function(resolve, reject){
      var url = 'api/my-cookie';
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


  /*-----------CATEGORIES-----------*/

  function categoriesGet(){
    var promise = new Promise(function(resolve, reject){
      var url = 'api/categories';
      var authKey = localStorage.getItem('STORAGE_AUTH_KEY');
      $.ajax({
        url:url,
        method:'GET',
        contentType: 'application/json',
        //headers: {
        //  'x-auth-key':authKey
        //},
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
      current: currentUser,
      all: getAllUsers
    },
    cookies: {
      all: getCookies,
      share: shareCookie,
      update: update,
      myCookie: myCookie
    },
    categories: {
      get: categoriesGet
    }
  }
}();