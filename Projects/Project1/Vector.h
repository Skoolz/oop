#pragma once
#include<iostream>
#include "Point.h"

class Vector {

private:
	Point *p1;
	Point *p2;


public:

	Vector() {

	}

	//Vector(const Point& _p1, const Point& _p2) : p1(_p1), p2(_p2) {
	//}

	Vector(const Vector& vector) : p1(vector.p1), p2(vector.p2) {
		this->p1 = new Point((vector.p1));
		this->p2 = new Point((vector.p2));
	}

	~Vector() {
		delete p1;
		delete p2;
	}

    Point& getP1() {
		return *p1;
	}
    Point& getP2() {
		return *p2;
	}

	float length();
	static void Print(const Vector&);


};