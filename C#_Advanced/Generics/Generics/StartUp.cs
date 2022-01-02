using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
   public class StartUp
    {
        public class Box<T>
        {
            private List<T> box;

            public Box()
            {
                box = new List<T>();
            }
            public void Add(T element)
            {
                box.Add(element);
            }

            public int Count => box.Count;
   
            public T Remove()
            {
                T elementToRemove = box.Last();
                box.RemoveAt(box.Count - 1);
                return elementToRemove;
            }
        }
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            box.Add(4);
            box.Add(5);
            Console.WriteLine(box.Remove());
        }
    }
}
