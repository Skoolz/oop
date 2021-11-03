#include <iostream>
#include "Point.h"
#include "Vector.h"
using namespace std;


int main() {

	Point p1;
	Point p2(4, 4);
	Point p3(p2);

	Point* dp1 = new Point();
	Point* dp2 = new Point(4, 6);
	Point* dp3 = new Point(p3);
	Point* dp4 = new Point(*dp3);
	cout << endl;
	delete dp1;
	delete dp2;
	delete dp3;
	delete dp4;
	cout << endl;

	p1.reset();
	Point::print(p1);
	cout << endl;

	Vector v(p1, p2);
	Vector::Print(v);
	cout << v.length() << endl;
	cout << endl;

	return 0;

}