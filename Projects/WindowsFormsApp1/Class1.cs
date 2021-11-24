using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CustomList
{

    public class Node<T>
    {
        public Node(T value, Node<T> node)
        {
            this.value = value;
            node.next = this;
        }

        public Node(T value)
        {
            this.value = value;
        }

        public T value;
        public Node<T> next=null;
    }


    public class DynamicList<T> :  IEnumerable<T>
    {
        public Node<T> start;
        private int _count=0;

        public string RandomStringFunc(T _object)
        {
            Type type = _object.GetType();
            var functions = type.GetMethods();
            List<MethodInfo> available_functions = new List<MethodInfo>();

            available_functions.AddRange(functions.Where(f =>
            f.GetParameters().Length == 0 &&
            f.ReturnType == typeof(string)).ToList());

            Random rnd = new Random();

            if (available_functions.Count == 0) return "No string function";

            int random_index = rnd.Next(available_functions.Count);
            var random_function = available_functions[random_index];
            string random_function_result = "";
            random_function_result += $"|Method name:{random_function}| ";
            random_function_result += $"|result:{(string)random_function.Invoke(_object, null)}|";
            return random_function_result;

        }

        public void DefaultFunc(T _object)
        {
            Console.WriteLine(_object.ToString());
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }
        public bool Contains(T item)
        {
            foreach(T _item in this)
            {
                if (_item.Equals(item)) return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = start;
            while(node!=null)
            {
                yield return node.value;
                node = node.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        

        public void Add(T item)
        {
            Node<T> new_node = new Node<T>(item);
            if (start == null) start = new_node;
            else
            {
                Node<T> node = start;
                while (node.next != null)
                {
                    node = node.next;
                }
                node.next = new_node;
            }
            _count= _count+1;
        }

        public void Remove(T item)
        {
            if (start == null) return;
            Node<T> node = start;
            Node<T> prev=null;
            while (node != null)
            {
                if(node.value.Equals(item))
                {
                    if (node == start && node.next != null)
                    {
                        start = node.next;
                    }
                    
                    if(prev!=null)
                    {
                        prev.next = node.next;
                    }
                    _count = _count-1;
                    return;
                }
                prev = node;
                node = node.next;
            }
        }

        public void Clear()
        {
            start = null;
            _count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > _count) return default(T);
                else
                {
                    Node<T> node = start;
                    for(int i = 0; i < index; i++)
                    {
                        node = node.next;
                    }
                    return node.value;
                }
            }
        }

    }
}
