#pragma once
#include<iostream>
#include "Point.h"

class Vector {

private:
	Point* p1;
	Point* p2;

public:

	Vector(Point& p1, Point& p2) {
		this->p1 = &p1;
		this->p2 = &p2;
	}

	float length();
	static void Print(const Vector&);


};