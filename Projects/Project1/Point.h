#pragma once
#include <iostream>
using namespace std;
class Point {

protected:
	int x, y;

public:

	Point() {
		x = 0;
		y = 0;
		cout << "Point with adress:" << this << ". Constructor 0" << endl;
	}
	Point(int x, int y) {
		this->x = x;
		this->y = y;
		cout << "Point with adress:" << this << ". Constructor 1" << endl;
	}
	Point(const Point& point) {
		this->x = point.x;
		this->y = point.y;
		cout << "Point with adress:" << this << ". Constructor 2" << endl;
	}
	~Point() {
		cout << "Point with adress:" << this << " was deleted" << endl;
	}

	static void print(const Point& point);
	void setPos(int x, int y);

	void reset() {
		x = 0;
		y = 0;
	}

	int getX() {
		return x;
	}
	int getY() {
		return y;
	}
};
