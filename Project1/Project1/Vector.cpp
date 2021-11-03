#include <iostream>
#include "Vector.h"
using namespace std;

float Vector::length() {
	float dx = p2->getX()-p1->getX();
	float dy = p2->getY() - p1->getY();
	return sqrt(dx * dx + dy * dy);
}

void Vector::Print(const Vector& v) {
	Point p(v.p2->getX()-v.p1->getX(),v.p2->getY()-v.p1->getY());
	Point::print(p);
}