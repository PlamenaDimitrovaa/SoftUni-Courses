﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> collection;
        public Stack(params T[] data)
        {
            collection = new List<T>(data);
        }

        public void Push(params T[] elements)
        {
            foreach (T element in elements)
            {
                collection.Insert(collection.Count, element);
            }
        }
        public T Pop()
        {          
            T element = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count - 1);
            return element;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
