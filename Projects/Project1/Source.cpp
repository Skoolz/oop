#include <iostream>
#include "Point.h"
#include "Vector.h"
using namespace std;


int main() {

	Point p1;
	Point p2(4, 4);
	Point p3(p2);
	cout << endl;

	Point* dp1 = new Point();
	Point* dp2 = new Point(4, 6);
	Point* dp3 = new Point(p3);
	Point* dp4 = new Point(*dp3);
	cout << endl;

	Vector *v = new Vector(*dp1,*dp2);
	Vector v2(*v);
	cout << v->getP1().getX() << endl;
	cout << v2.getP1().getX() << endl;
	cout << endl;
	delete v;
	cout << v2.getP1().getX() << endl;
	cout << endl;

	delete dp1;
	delete dp2;
	delete dp3;
	delete dp4;
	cout << endl;

	p1.reset();
	Point::print(p1);
	cout << endl;


	return 0;

}