#include <iostream>
#include "Point.h"

using namespace std;

void Point::print(const Point& p) {
	cout << "x:" << p.x << ", y:" << p.y <<endl;
}

void Point::setPos(int x,int y) {
	this->x = x;
	this->y = y;
}