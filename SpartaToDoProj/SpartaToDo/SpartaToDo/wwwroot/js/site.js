// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

class Balloon {
    constructor() {
        this.x = random(width);
        this.y = random(height);
        this.r = 25;
        this.vx = 0;
        this.vy = 0;

        this.col = color(random(255), random(255), random(255));
        this.popped = false;
    }

    blownAway() {
        if (!this.popped) {
            //calculate the blow away force
            let d = dist(this.x, this.y, mouseX, mouseY);
            //js ternary operator below
            let force = d < height / 2 ? -10 / (d * d) : 0;

            //apply the force to the existing velocity
            this.vx += force * (mouseX - this.x);
            this.vy += force * (mouseY - this.y);
        }
        //also add some friction to take energy out of the system
        this.vx *= 0.95;
        this.vy *= 0.95;
        //update the position
        this.x += this.vx;
        this.y += this.vy;
    }

    checkBounds() {
        //make balloon wrap to the other side of the canvas
        if (this.x < 0) this.x = width;
        if (this.x > width) this.x = 0;
        if (this.y < 0) this.y = height;
        if (this.y > height) this.y = 0;
    }

    checkToPop() {
        if (!this.popped && dist(this.x, this.y, mouseX, mouseY) < this.r) {
            this.popped = true;
            let currScore = Number(document.getElementById("score").innerHTML);
            currScore++;
            document.getElementById("score").innerHTML = currScore;
            this.col = color(156);
        }
    }
}

let balloons = [];
const NUM_OF_BALLOONS = 25;

function resetGame() {
    for (let i = 0; i < NUM_OF_BALLOONS; i++) {
        balloons[i].remove();
        balloons[i].clear();
        balloons[i].col = color(250);
    }
}

function setup() {
    let canvas = createCanvas(640, 480);
    //THIS IS WHAT IS CAUSING PROBLEMS
    canvas.parent("game-container");

    for (let i = 0; i < NUM_OF_BALLOONS; i++) {
        balloons[i] = new Balloon();
    }
}
function draw() {
    //a nice sky blue background
    background(135, 206, 235);

    for (let i = 0; i < NUM_OF_BALLOONS; i++) {
        fill(balloons[i].col);
        circle(balloons[i].x, balloons[i].y, balloons[i].r);
        balloons[i].blownAway();
        balloons[i].checkBounds();
        balloons[i].checkToPop();
    }
}

var x = document.getElementById("resetButton");

resetButton.addEventListener("click", function () {
    setup();
});
