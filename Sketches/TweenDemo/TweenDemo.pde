

float x1 = 20;
float x2 = 780;

float duration = 2;
float currTime = 0;

float prevTime = 0;

void setup() {
  size(800, 500);
}

void draw() {
  background(200);
  
  float timeStamp = millis()/1000.0;
  float dt = timeStamp - prevTime;
  prevTime = timeStamp;

  if(currTime < duration) currTime += dt;
  
  float p = currTime/duration;
  
  p = constrain(p, 0, 1);
  
  float flipP = 1 - (1-p) * (1-p);
  float swerveP = p * p * (3 - 2*p);
  
  float currX = lerp(x1, x2, swerveP);
  
  fill(255);
  ellipse(currX, height/2, 30, 30);
  
}

void mousePressed() {
   currTime = 0; 
}
