var utilities = function(){

function processUserButtons(){
  if(data.users.current()) {
    $('#login-btn').hide();
    $('#register-btn').hide();
    $('#logout-btn').show();
    $('#all-users-btn').show();
    $('#add-cookie').show();
    $('#my-cookie').show();

  }
  else{
    $('#login-btn').show();
    $('#register-btn').show();
    $('#logout-btn').hide();
    $('#all-users-btn').hide();
    $('#add-cookie').hide();
    $('#my-cookie').hide();
  }
}

  return{
    processUserButtons:processUserButtons
  }
}();