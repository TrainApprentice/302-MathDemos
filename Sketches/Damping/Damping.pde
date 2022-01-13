float x1, x2, x3;

float v2;

void setup() {
    size(500, 500, P2D);
}

void draw() {
   background(200); 
   
   // Ellipse 1 movement: linear
   if(x1 < mouseX) {
      x1 += 5;
      if(x1 > mouseX) x1 = mouseX;
   }
   else {
      x1 -= 5;
      if(x1 < mouseX) x1 = mouseX;
   }
   
   // Ellipse 2 movement: physics
   if(x2 < mouseX) v2++;
   else v2--;
   
   v2 *= .95;
   x2 += v2;
   
   // Ellipse 3 movement: damping
   
   //x3 += (mouseX - x3) * .1;
   x3 = lerp(x3, mouseX, .1);
   
   
   ellipse(x1, height/4, 25, 25);
   ellipse(x2, height/2, 25, 25);
   ellipse(x3, height * 3/4, 25, 25);
}
