using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {

        static void Main(string[] args)
        {

            DynamicList<object> list = new DynamicList<object>();
            int count = Convert.ToInt32(Console.ReadLine());
            Random rnd = new Random();
            for(int i = 0; i < count; i++)
            {
                int choose = rnd.Next(4);
                switch (choose)
                {
                    case 0:list.Add(rnd.Next(500)); break;
                    case 1:list.Add(RandomString(rnd.Next(10))); break;
                    case 2:list.Add(new TestClass()); break;
                    case 3:list.Add(new BaseTestClass()); break;
                }
            }
            foreach(object _object in list)
            {
                Console.WriteLine($"|object type:{_object.GetType()}| "+list.RandomStringFunc(_object));
                //list.DefaultFunc(_object);
            }

        }

        public static string RandomString(int length)
        {
            string str="";
            Random rnd = new Random();
            for (int i = 0; i < length; i++) str += (char)rnd.Next('A', 'Z');
            return str;
        }

    }
}
