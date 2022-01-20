

void setup() {
   size(800, 500); 
}

void draw() {
  background(200);
  float time = millis()/1000.0;
  
  float mult = 2;
  // Range: 0 - 20
  float t = (sin(time * mult) * 10) + 10;
  
  stroke(t * 12, 0, t * 12);
  strokeWeight(t);
  ellipse(width/2, height/2, 300, 300);
}
