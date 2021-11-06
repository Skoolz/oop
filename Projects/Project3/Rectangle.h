#pragma once
#include <iostream>;
#include "Shape.h"
#include "Vector2.h"
using namespace std;

class Rectangle : Shape {

protected:
	Vector2 size;

public:

	Rectangle() {
		size = Vector2(0, 0);
		cout << "Rectangle() " << this << endl;
	}

	Rectangle(float x, float y) {
		size = Vector2(x, y);
		cout << "Rectangle(float x, float y) " << this << endl;
	}

	Rectangle(const Rectangle& rect) {
		this->size = rect.size;
		cout << "Rectangle(const Rectangle& rect) " << this << endl;
	}

	void SetSize(Vector2 new_size) {
		this->size = new_size;
	}
	const Vector2& GetSize() {
		return size;
	}

	float Square() override {
		return size.x * size.y;
	}

	~Rectangle() {
		cout << "Rectangle " << this << " destructor" << endl;
	}

};