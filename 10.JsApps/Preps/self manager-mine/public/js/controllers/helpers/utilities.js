var utilities = function(){

function processUserButtons(){
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
}

  return{
    processUserButtons:processUserButtons
  }
}();