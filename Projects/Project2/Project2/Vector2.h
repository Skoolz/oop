#pragma once
#include <iostream>

class Vector2 {
public:

	Vector2() {
		x = 0;
		y = 0;
	}
	Vector2(float x, float y) {
		this->x = x;
		this->y = y;
	}
	Vector2(const Vector2& v2) {
		this->x = v2.x;
		this->y = v2.y;
	}

	Vector2& operator=(const Vector2& v2) {
		this->x = v2.x;
		this->y = v2.y;
		return *this;
	}

	float x;
	float y;
};

std::ostream& operator << (std::ostream& out, const Vector2& v2)
{
	out << v2.x << "," << v2.y;
	return out;
}