using System;
using System.Collections;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {

        static void Main(string[] args)
        {

            DynamicList<object> list = new DynamicList<object>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            foreach (var item in list) Console.WriteLine(item);
            Console.WriteLine();
            list.Remove(2);
            foreach (var item in list) Console.WriteLine(item);
            Console.WriteLine(list.Count);

        }

    }
}
