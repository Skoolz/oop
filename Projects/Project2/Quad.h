#pragma once
#include "Rectangle.h"

class Quad : public Rectangle {

public:

	Quad(float x) : Rectangle(x, x) {
	}

	Quad(const Quad& quad) : Rectangle(quad) {
	}

	void SetSize(float x) {
		Rectangle::SetSize(Vector2(x, x));
	}

	~Quad() {
		cout << "Quad " << this << " destructor" << endl;
	}

};