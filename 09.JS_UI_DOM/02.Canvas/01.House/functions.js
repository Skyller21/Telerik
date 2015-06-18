var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');
var ctx3D = canvas.getContext('2d');
var centerX = canvas.width / 2;
var centerY = canvas.height / 2;

ctx.beginPath();
ctx.lineWidth = 3;
ctx.moveTo(3 * centerX / 4 + centerX, 270);
ctx.lineTo(centerX / 4, 270);
ctx.lineTo(centerX / 4, canvas.height - 2);
ctx.lineTo(3 * centerX / 4 + centerX, canvas.height - 2);
ctx.lineTo(3 * centerX / 4 + centerX, 270);
ctx.lineTo(centerX, 75);
ctx.lineTo(centerX / 4, 270);
ctx.fillStyle = 'brown';
ctx.fill();
ctx.stroke();


ctx.beginPath()
ctx.rect(120, 320, 150, 85)
ctx.fillStyle = 'black';

ctx.rect(330, 320, 150, 85)
ctx.fillStyle = 'black';

ctx.rect(330, 460, 150, 85)
ctx.fillStyle = 'black';


ctx.strokeStyle = 'brown'
ctx.lineWidth = 3;
ctx.moveTo(120, 362.5)
ctx.lineTo(270, 362.5)

ctx.moveTo(330, 362.5)
ctx.lineTo(480, 362.5)

ctx.moveTo(330, 502.5)
ctx.lineTo(480, 502.5)

ctx.moveTo(195, 320)
ctx.lineTo(195, 405)

ctx.moveTo(405, 320)
ctx.lineTo(405, 405)

ctx.moveTo(405, 460)
ctx.lineTo(405, 545)

ctx.fill()
ctx.stroke();


ctx.beginPath()
ctx.strokeStyle = 'black';
ctx.moveTo(centerX / 2, canvas.height - 2)
ctx.lineTo(centerX / 2, 500)
ctx.ellipse(centerX / 2 + 50, 500, 50, 25, 0, Math.PI, 0)
ctx.lineTo(centerX / 2 + 100, canvas.height - 2);
ctx.moveTo(centerX / 2 + 50, canvas.height - 2)
ctx.lineTo(centerX / 2 + 50, 475)
ctx.moveTo(centerX / 2 + 40, 550)
ctx.arc(centerX / 2 + 36, 550, 4, 0, 2 * Math.PI)
ctx.moveTo(centerX / 2 + 66, 550)
ctx.arc(centerX / 2 + 62, 550, 4, 0, 2 * Math.PI)
ctx.stroke()

ctx.beginPath()
ctx.strokeStyle = 'brown'
ctx.strokeStyle = 'black';
ctx.moveTo(400, 220)
ctx.lineTo(400, 120)
ctx.ellipse(420, 120, 20, 7, 0, Math.PI, 0)
ctx.lineTo(440, 220)
ctx.fillStyle = 'brown'
ctx.fill()
ctx.stroke()






