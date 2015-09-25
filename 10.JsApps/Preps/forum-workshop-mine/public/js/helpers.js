var helpers = (function(){

    function logBtnHide(){
        if(data.users.current()){
            $('#btn-login-register').hide();
            $('#btn-logout').show();
            $('#btn-threads-add').show();
        }else{
            $('#btn-login-register').show();
            $('#btn-logout').hide();
            $('#btn-threads-add').hide();
        }

    }

    return {
        logBtnHide: logBtnHide
    }

}());