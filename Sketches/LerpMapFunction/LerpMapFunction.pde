

void setup() {
   size(500, 500); 
}

void draw() {
   background(200);
   
   //float pd = mouseX/(float)width;
   //float d = doLerp(10, 450, pd);
   float d = doMap(mouseX, 0, width, 10, 450);
   ellipse(width/2, height/2, d, d);
}

float doLerp(float min, float max, float percent) {
  return (max - min) * percent + min;
}

float doMap(float value, float inMin, float inMax, float outMin, float outMax) {
  return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
  
}
