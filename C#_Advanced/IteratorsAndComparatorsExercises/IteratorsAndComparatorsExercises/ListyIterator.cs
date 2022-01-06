using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparatorsExercises
{
  public class ListyIterator<T>
    {
        private List<T> collection;
        private int currentIndex;
        public ListyIterator(params T[] data)
        {
            collection = new List<T>(data);
            currentIndex = 0;
        }

        public bool HasNext()
        {
            return currentIndex < collection.Count - 1;
        }

        public bool Move()
        {
            bool canMove = HasNext();
            if (canMove)
            {
                currentIndex++;
            }

            return canMove;
        }

        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            Console.WriteLine($"{collection[currentIndex]}");
        }
    }
}
