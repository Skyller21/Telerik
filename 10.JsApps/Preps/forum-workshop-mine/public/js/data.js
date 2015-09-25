var data = (function(){

    function usersLogin(user){
        var promise = new Promise(function (resolve, reject) {

            var reqUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            }
            $.ajax({
                url:'api/auth',
                method: 'PUT',
                data: JSON.stringify(reqUser),
                contentType: 'application/json',
                success: function(resUser){
                    localStorage.setItem('AUTH_KEY_STORAGE',resUser.authKey);
                    localStorage.setItem('USERNAME_STORAGE',resUser.username);
                    resolve(resUser);
                }
            })
        });

        return promise;
    }

    function usersRegister(user){
        var promise = new Promise(function (resolve, reject) {
            var reqUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            }
            $.ajax({
                url: 'api/users',
                method: 'POST',
                data: JSON.stringify(reqUser),
                contentType: 'application/json',
                success: function (resUser) {
                    localStorage.setItem('AUTH_KEY_STORAGE', resUser.authKey);
                    localStorage.setItem('USERNAME_STORAGE', resUser.username);
                    resolve(resUser);
                }
            })
        });

        return promise;
    }

    function usersLogout(){
        var promise = new Promise(function (resolve, reject) {
            localStorage.removeItem('AUTH_KEY_STORAGE');
            localStorage.removeItem('USERNAME_STORAGE');
            resolve();
        });

        return promise;
    }

    function getCurrentUser(){
        var username = localStorage.getItem('USERNAME_STORAGE');
        if(!username){
            return null;
        }else{
            return {
                username
            }
        }

    }

    function threadsGet(){

        var promise = new Promise(function (resolve, reject) {

            $.ajax({
                url: 'api/threads',
                method: 'GET',
                contentType: 'application/json',
                success: function (threads) {
                    resolve(threads);
                }
            })
        });

        return promise;
    }

    function threadAdd(title){
        var promise = new Promise(function (resolve, reject) {
            var body = {
                title
            }
            $.ajax({
                url: 'api/threads',
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(body),
                headers: {
                    'x-authkey':localStorage.getItem('AUTH_KEY_STORAGE')
                },
                success: function (res) {
                    resolve(res);
                }
            })
        });

        return promise;
    }

    function getById(id){
        var promise = new Promise(function (resolve, reject) {

            $.ajax({
                url: 'api/threads/'+id,
                method: 'GET',
                contentType: 'application/json',

                success: function (res) {
                    res.result.postDate = moment(res.result.postDate).format("MMM Do, YYYY")
                    resolve(res);
                }
            })
        });

        return promise;
    }

    return {
        users: {
            login: usersLogin,
            register: usersRegister,
            logout: usersLogout,
            current: getCurrentUser
        },
        threads:{
            all: threadsGet,
            add: threadAdd,
            getById:getById
        }
    }
}())