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
            list.Add(1);
            list.Add(3);
            list.Add(2);

            list.Remove(1);
            Console.WriteLine(list[0]);
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
