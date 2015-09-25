var items =[];

function add() {
    console.log(new Date());
    setTimeout(add, 1000);
}
export default {add};
