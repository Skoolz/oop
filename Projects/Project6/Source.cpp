#include <iostream>
#include <memory>

using namespace std;

class Base {
public:
	~Base() {
		cout << "~Base()" << endl;
	}
};

int main() {

	unique_ptr<Base>ptr(new Base());
	unique_ptr<Base>ptr2;
	ptr2.swap(ptr);

	shared_ptr<Base>sptr1(new Base());
	shared_ptr<Base>sptr2(sptr1);

	shared_ptr<Base>sptr3(new Base());

	cout << sptr1.get() << endl;
	cout << sptr2.get() << endl;

	cout << "Reset sptr1" << endl;
	sptr1.reset();
	cout << "End Reset sptr1" << endl;
	cout << endl;
	cout << "Reset sptr3" << endl;
	sptr3.reset();
	cout << "End Reset sptr3" << endl;
	cout << endl;
	return 0;
}