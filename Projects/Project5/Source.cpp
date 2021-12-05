#include <iostream>

using namespace std;

class Base {
	
public:
	void method() {

	}
	int a = 0;
	Base() {
		cout << this << " Base()" << endl;
	}
	Base(Base& base) {
		cout << this << " Base(&base)" << endl;
	}
	Base(Base* base) {
		cout << this << " Base(*base)" << endl;
	}
	~Base() {
		cout << this << " ~Base()" << endl;
	}

};

class Desc :public Base {
public:
	Desc() {
		cout << this << " Desc()" << endl;
	}
	Desc(Desc& Desc) : Base(Desc) {
		cout << this << " Desc(&Desc)" << endl;
	}
	Desc(Desc* Desc) : Base(Desc) {
		cout << this << " Desc(*Desc)" << endl;
	}
	~Desc() {
		cout << this << " ~Desc()" << endl;
	}
};

void func1(Base base) {
	
}
void func2(Base &base) {

}
void func3(Base *base) {
}

Base func11() {
	Base base;
	return base;
}
Base& func22() {
	Base base;
	return base;
}
Base* func33() {
	Base* base = new Base();
	base->a = 14;
	return base;
}

int main() {

	Base base;
	Desc desc;
	func1(base);
	func2(base);
	func3(&base);
	cout << endl;
	func1(desc);
	func2(desc);
	func3(&desc);
	cout << endl;
	Base* b = new Desc();
	func1(*b);
	func2(*b);
	func3(b);
	cout << endl;
	func11();
	Base *b22;
	b22 = &func22();
	Base*b33= func33();
	cout << b22->a << endl;
	cout << b33->a << endl;

	cout << endl;
}