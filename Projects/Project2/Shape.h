#pragma once
#include <iostream>;
using namespace std;
class Shape {

public:
	Shape() {
		cout << "Shape " << this << " was created" << endl;
	}
	virtual float Square() {
		cout << "Shape class method" << endl;
		return 0;
	}

	~Shape() {
		cout << "Shape " << this << " destructor" << endl;
	}

};