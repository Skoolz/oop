#pragma once
#include "Rectangle.h"

class Quad : public Rectangle {

public:

	Quad():Rectangle() {
		cout << "Quad() " << this << endl;
	}

	Quad(float x) : Rectangle(x, x) {
		cout << "Quad(x) " << this << endl;
	}

	Quad(const Quad& quad) : Rectangle(quad) {
		cout << "Quad(const Quad& quad) " << this << endl;
	}

	void SetSize(float x) {
		Rectangle::SetSize(Vector2(x, x));
	}

	~Quad() {
		cout << "Quad " << this << " destructor" << endl;
	}

};