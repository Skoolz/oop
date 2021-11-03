#include <iostream>
#include "Shape.h";
#include "Rectangle.h"
#include "Vector2.h"
#include "Quad.h"
using namespace std;


int main() {

	Rectangle rect(4.5, 1.2);
	Quad quad(4);
	
	Quad* dquad = new Quad(quad);
	Rectangle* drect = new Rectangle(rect);
	Rectangle* drect1 = new Quad(quad);

	delete dquad;
	delete drect;
	delete drect1;

	return 0;
}