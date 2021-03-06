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
		cout << "Point() " << this << endl;
	}
	Point(int x, int y) {
		this->x = x;
		this->y = y;
		cout << "Point(int x, int y) " << this << endl;
	}
	Point(const Point& point) {
		this->x = point.x;
		this->y = point.y;
		cout << "Point(const Point& point) " << this << endl;
	}
	Point(const Point* point) {
		this->x = point->x;
		this->y = point->y;
		cout << "Point*(const Point& point) " << this << endl;
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
	void func1(Point point) {
		point.x = 4;
		cout << "fun1 point" << endl;
	}
	void func2(Point& point) {
		point.x = 4;
		cout << "func1 &point" << endl;
	}
	void func3(Point* point) {
		cout << &point << endl;
		point->x = 5;
	}

};
