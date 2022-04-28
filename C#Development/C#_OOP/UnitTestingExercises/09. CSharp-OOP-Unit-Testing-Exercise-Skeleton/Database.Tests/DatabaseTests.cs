using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(16)]
        [TestCase(0)]
        public void AddMethodShouldAddNewElementWhileCountIsLessThan16(int count)
        {
            Database.Database database = new Database.Database();
            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }
            Assert.AreEqual(count, database.Count);
        }

        [Test]

        public void AddMethodShouldThrowExceptionWhenItemsAreAbove16()
        {
            Database.Database database = new Database.Database();
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(5));
        }

        [Test]
        [TestCase(1, 4)]
        [TestCase(1, 15)]
        [TestCase(1, 16)]
        public void ConstructorShouldAddItemsWhileTheyAreBelow16(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();
            Database.Database database = new Database.Database(elements);
            Assert.AreEqual(count, database.Count);
        }

        [Test]
        [TestCase(1, 17)]
        [TestCase(1, 25)]
        public void ConstructorShouldThrowExceptionWhenItemsAreAbove16(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();
            Assert.Throws<InvalidOperationException>(() => new Database.Database(elements));
        }

        [Test]
        [TestCase(1, 10, 3, 7)]
        [TestCase(1, 5, 4, 1)]

        public void RemoveMethodShouldRemoveElementsWhenTheyAreAbove0(int start, int count, int toRemove, int result)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();
            Database.Database database = new Database.Database(elements);
            for (int i = 0; i < toRemove; i++)
            {
                database.Remove();
            }
            Assert.AreEqual(result, database.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenElementsAre0()
        {
            Database.Database database = new Database.Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchShouldReturnAllValidItems()
        {
            Database.Database database = new Database.Database(1, 2, 3);
            database.Add(4);
            database.Add(5);

            database.Remove();
            database.Remove();
            database.Remove();

            int[] fetchedData = database.Fetch();
            int[] expectedData = new int[] { 1, 2 };
            Assert.AreEqual(expectedData, fetchedData);
        }
    }
}