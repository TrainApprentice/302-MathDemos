

void setup() {
  size(500,500);
  rectMode(CENTER);
}

void draw() {
  background(200);
  
  //float p = mouseX / (float)width;
  //float a = lerp(0, 6.28, p);
  
  float a = map(mouseX, 0, width, 0, (float)Math.PI * 2);
  
  pushMatrix();
  
  translate(width/2, height/2);
  rotate(a);
  fill(255);
  rect(0, 0, 100, 100);
  popMatrix();
}
