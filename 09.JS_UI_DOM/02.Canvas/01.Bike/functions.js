var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');
var centerX = canvas.width / 2;
var centerY = canvas.height / 2;
ctx.lineWidth = 3;
ctx.fillStyle='dodgerblue';
ctx.font='50px Arial';
ctx.fillText('The Bike :)',200,100);

//Begin draw
ctx.beginPath();
//Paddles
ctx.arc(centerX,centerY,20,0,2*Math.PI);
//Frame
ctx.moveTo(centerX,centerY);
ctx.lineTo(260,180);
ctx.moveTo(275,220);
ctx.lineTo(150,centerY);
ctx.lineTo(centerX,centerY);
ctx.lineTo(460,220);
ctx.closePath();

//Front tube
ctx.moveTo(480,centerY);
ctx.lineTo(450,170);

//Steering
ctx.lineTo(480,140);
ctx.moveTo(450,170);
ctx.lineTo(400,180);

//Saddle
ctx.moveTo(240,180);
ctx.lineTo(280,180);
ctx.stroke();

//Rear wheel
ctx.beginPath();
ctx.arc(150,centerY,70,0,2*Math.PI);
ctx.fill();
ctx.stroke();

//Front wheel
ctx.beginPath();
ctx.arc(480,centerY,70,0,2*Math.PI);
ctx.fill();
ctx.stroke();
