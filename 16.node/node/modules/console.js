var msgPrefix = 'Message: ';

function write(msg){
    console.log(msgPrefix + msg);
}

module.exports = {
    write: write
}
