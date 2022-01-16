// Animate 3 electrons orbiting around a nucleus.
// Each electron should follow a path and match
// colors with its respective path.

// Don't use rotate()
// Use vectors and trigonometry

void setup(){
  size(400, 400);
}
void draw(){
  
  drawBackground();
  
  ///////////////// START YOUR CODE HERE:
  
  
  // Create vectors to hold each electron's position
  PVector elRed = new PVector();
  PVector elBlue = new PVector();
  PVector elGreen = new PVector();
  
  // Store the time in seconds for movement
  float time = (float)millis()/1000;
  
  // Set up the red electron's movement
  elRed.x = 150 * cos(time * 1.5);
  elRed.y = 50 * sin(time * 1.5);
  
  // Convert the red electron's position into polar coordinates
  float angle = atan2(elRed.y, elRed.x);
  float mag = sqrt(elRed.x * elRed.x + elRed.y * elRed.y);
  
  // Set the other electrons based on the red electron
  elBlue.x = mag * cos(angle + radians(60));
  elBlue.y = mag * sin(angle + radians(60));
  
  elGreen.x = mag * cos(angle - radians(60));
  elGreen.y = mag * sin(angle - radians(60));

  // Draw all electrons
  noStroke();
  fill(255,100,100);
  ellipse(elRed.x + 200, elRed.y+200, 20, 20);
  fill(100,100,255);
  ellipse(elBlue.x + 200, elBlue.y + 200, 20, 20);
  fill(100,255,100);
  ellipse(elGreen.x + 200, elGreen.y + 200, 20, 20);
  
  
  ///////////////// END YOUR CODE HERE
  
}
void drawBackground(){
  background(0);
  noStroke();
  fill(255);
  ellipse(200,200,50,50);
  noFill();
  strokeWeight(5);
  
  pushMatrix();
  translate(200,200);
  stroke(255,100,100);
  ellipse(0,0,300,100);
  popMatrix();
  
  pushMatrix();
  translate(200,200);
  rotate(PI/1.5);
  stroke(100,255,100);
  ellipse(0,0,300,100);
  popMatrix();
  
  pushMatrix();
  translate(200,200);
  rotate(2*PI/1.5);
  stroke(100,100,255);
  ellipse(0,0,300,100);
  popMatrix();
}
