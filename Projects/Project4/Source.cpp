#include <iostream>
using namespace std;

int func() {
	int a = 10;
	cout << &a << endl;
	return a;
}

class Point {
protected:
	int x=0;
	int y=0;
public:
    virtual void DisplayInfo() {
		cout << x << " " << y << endl;
	}

    string className() {
		return "Point";
	}

	virtual string vclassName() {
		return className();
	}

	virtual bool isA(string class_name) {
		return className() == class_name;
	}

};

class ColoredPoint : public Point {
protected:
	int color = 0;
public:
	void DisplayInfo() {
		Point::DisplayInfo();
		cout << color << endl;
	}

	string className() {
		return "ColoredPoint";
	}
	string vclassName() {
		return className();
	}

	bool isA(string class_name) {
		return className() == class_name || Point::isA(class_name);
	}
};

class Point3d :public Point {
protected:
	int z = 0;

public:

	Point3d() {
		z = rand() % 10;
	}

	void DisplayInfo() {
		Point::DisplayInfo();
		cout << z << endl;
	}

	string className() {
		return "Point3d";
	}
	string vclassName() {
		return className();
	}

	bool isA(string class_name) {
		return className() == class_name || Point::isA(class_name);
	}

	int GetZ() {
		return z;
	}
};

class Radious3dPoint :public Point3d {
protected:
	int radious = 1;
public:
	void DisplayInfo() {
		Point::DisplayInfo();
		cout << z << endl;
	}

	bool isA(string class_name) {
		return className() == class_name || Point3d::isA(class_name);
	}

	string className() {
		return "Radious3dPoint";
	}
	string vclassName() {
		return className();
	}
};



int main() {
	srand(time(0));
	Point* points[10];

	for (int i = 0; i < 10; i++) {
		if (rand() % 2 == 0)points[i] = new ColoredPoint();
		else points[i] = new Radious3dPoint();
	}

	for (int i = 0; i < 10; i++) {
		if (points[i]->vclassName() == "Point3d" || points[i]->vclassName()== "Radious3dPoint") {
			cout << "z=" << ((Point3d*)points[i])->GetZ() << endl;
		}
	}
	cout << endl;
	for (int i = 0; i < 10; i++) {
		if (points[i]->isA("Point3d")) {
			cout << "z=" << ((Point3d*)points[i])->GetZ() << endl;
		}
	}
	cout << endl;

	for (int i = 0; i < 10; i++) {
		Point3d* p3d = dynamic_cast<Point3d*>(points[i]);
		if(p3d!=NULL) cout << "z=" << p3d->GetZ() << endl;
	}

}

