using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BaseTestClass
    {
        private string name = "";

        public BaseTestClass()
        {
            Random rnd = new Random();
            int length = rnd.Next(1, 10);
            for(int i = 0; i < length; i++)
            {
                name += (char)rnd.Next(62, 123);
            }
        }

        public string getName() => $"Name of object:{name}";

        public virtual string TestFunc() => "Test func of base test class";

    }

    public class TestClass:BaseTestClass
    {
        public TestClass() : base()
        {

        }
        public override string TestFunc() => "Test func of test class";
    }
}
