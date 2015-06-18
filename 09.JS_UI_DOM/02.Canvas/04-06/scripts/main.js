var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');

var input = new Input();
attachListeners(input);

var player1 = new Player(canvas.width/2, canvas.height-48);
var player2 = new Player(canvas.width/2, 1);
var ball = new Ball(canvas.width/2, 100);
ball.movement.right = true;
ball.movement.down = true;

var previousTime = Date.now();


function update() {
    this.tick();
    this.render(ctx);
    requestAnimationFrame(update);
}

function tick() {
    moveplayer1();
    moveplayer2();
    modifyballSpeed();

    if((ball.position.x+ball.width)>=canvas.width) {

            ball.movement.right = false;
            ball.movement.left = true;

    }

    if(ball.position.x<=0) {

        ball.movement.right = true;
        ball.movement.left = false;

    }

    if(ball.boundingBox.intersects(player2.boundingBox)){
        ball.movement.up = false;
        ball.movement.down = true;
    }

    if(ball.boundingBox.intersects(player1.boundingBox)){
        ball.movement.up = true;
        ball.movement.down = false;
    }

    ball.update();
    player1.update();
    player2.update();
}

function render(ctx) {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    player1.render(ctx);
    player2.render(ctx);
    ball.render(ctx);
}

function moveplayer1() {
    player1.movement.right = !!input.right;
    player1.movement.left = !!input.left;

}

function moveplayer2() {
    player2.movement.right = !!input.d;
    player2.movement.left = !!input.a;

}

function modifyballSpeed() {
    var now = Date.now();
    var difference = Math.abs(now - previousTime) / 1000;
    if(difference >= 10) {
        previousTime = now;
        ball.velocityModifier += 0.1;
    }
}

update();