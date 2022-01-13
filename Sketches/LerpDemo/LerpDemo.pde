

void setup() {
  size(500, 500);
}

void draw() {
  background(200);
  
  float pd = mouseX / (float)width;
  
  float d = lerp(50, 400, pd);
  
  float pw = mouseY / (float)height;
  
  float w = lerp(1, 20, pw);
  
  strokeWeight(w);
  stroke(255);
  fill(0);
  ellipse(width/2, height/2, d, d);
}
