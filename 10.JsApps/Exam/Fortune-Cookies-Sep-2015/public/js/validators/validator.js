var validator = function() {

  var minLength = 6;
  var maxLength = 30;


  function validateLength(text) {
    text = text.trim();
      if(6<= text.length && text.length<=30){
        return text;
      }else{
        return null;
      }
  }

  function validateSymbols(text){
    var regex = /^[.a-zA-Z0-9_.]{6,30}$/;

    if(!text.match(regex)){
      return null;
    }
    else{
      return text;
    }
  }


  function validatUrl(text){
    var regex = "^(http[s]?:\\/\\/(www\\.)?|ftp:\\/\\/(www\\.)?|www\\.){1}([0-9A-Za-z-\\.@:%_\+~#=]+)+((\\.[a-zA-Z]{2,3})+)(/(.)*)?(\\?(.)*)?";

    if(!text.match(regex)){
      return null;
    }
    else{
      return text;
    }

  }

  return {
    validateLength: validateLength,
    validateSymbols: validateSymbols,
    validateUrl: validatUrl
  }
}();