#include <iostream>

using namespace std;

class BaseClass {

public:

	void func1() {
		func2();
	}

    void func2() {
		cout << "func2 BaseClass" << endl;
	}

	~BaseClass() {
		cout << "~Baseclass" << endl;
	}

	void func3() {
		cout << "func3 BaseClass" << endl;
	}

};

class TestClass : public BaseClass {

public:
	void func2() {
		cout << "func2 TestClass" << endl;
	}

	~TestClass() {
		cout << "~Testclass" << endl;
	}

	void func3() {
		cout << "func3 TestClass" << endl;
	}

};

class VirtualBaseClass {

public:

	void func1() {
		func2();
	}

	virtual void func2() {
		cout << "func2 VirtualBaseClass" << endl;
	}

	virtual ~VirtualBaseClass() {
		cout << "~VirtualBaseclass" << endl;
	}

	virtual void func3() {
		cout << "func3 VirtualBaseClass" << endl;
	}
};

class VirtualTestClass : public VirtualBaseClass {

public:
	void func2() {
		cout << "func2 VirtualTestClass" << endl;
	}

	~VirtualTestClass() {
		cout << "~VirtualTestclass" << endl;
	}

	void func3() {
		cout << "func3 VirtualTestClass" << endl;
	}
};



int main() {

	TestClass t;
	t.func1();

	VirtualTestClass vt;
	vt.func1();

	BaseClass* dt = new TestClass();
	VirtualBaseClass* vdt = new VirtualTestClass();

	TestClass* dt2 = new TestClass();
	VirtualTestClass* vdt2 = new VirtualTestClass();

	dt->func3();
	dt2->func3();
	vdt->func3();
	vdt2->func3();
	cout << endl;
	cout << "deleting dt" << endl;
	delete dt;
	cout << "deleting vdt" << endl;
	delete vdt;
	cout << endl;
	delete dt2;
	delete vdt2;

}