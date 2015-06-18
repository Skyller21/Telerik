var Ball = (function () {
    function Ball(x, y) {
        this.width = 29;
        this.height = 30;
        this.velocity = 1.5;
        this.velocityModifier = 0;
        this.movement = {left: false, right : false, up: false, down : false};
        this.isHit = false;


        this.position = new Vector2(x, y);
        this.animation = new Animation(this.width, this.height, 0, 0, 1, 'ressources/images/ball.PNG', 1, 1, 1);
        this.boundingBox = new Rectangle(x, y, this.width, this.height);
    }

    Ball.prototype.update = function () {
        if(this.movement.right && !this.isHit) {
            this.position.x += this.velocity + this.velocityModifier;
        }

        if(this.movement.down && !this.isHit) {
            this.position.y += this.velocity + this.velocityModifier;
        }

        if(this.movement.left && !this.isHit) {
            this.position.x -= this.velocity + this.velocityModifier;
        }

        if(this.movement.up && !this.isHit) {
            this.position.y -= this.velocity + this.velocityModifier;
        }

        this.animation.position.set(this.position.x, this.position.y);
        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;
        this.animation.update();
    };

    Ball.prototype.render = function(ctx) {
        this.animation.draw(ctx);
    };

    return Ball;
}());