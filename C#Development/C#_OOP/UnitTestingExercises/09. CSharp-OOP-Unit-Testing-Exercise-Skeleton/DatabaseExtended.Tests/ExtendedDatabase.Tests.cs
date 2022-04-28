using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDb;
        [SetUp]
        public void Setup()
        {
            extendedDb = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void ConstructorAddInitialPeopleToTheDb()
        {
            var persons = new Person[5];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"Name: {i}");
            }

            extendedDb = new ExtendedDatabase.ExtendedDatabase(persons);
            Assert.That(extendedDb.Count, Is.EqualTo(persons.Length));

            foreach (var person in persons)
            {
                Person dbPerson = extendedDb.FindById(person.Id);
                Assert.That(person, Is.EqualTo(dbPerson));
            }
        }

        [Test]
        public void ConstructorShouldThrowAnExceptionWhenCapacityIsExceeded()
        {
            var persons = new Person[17];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"Pesho: {i}");
            }
            Assert.Throws<ArgumentException>(() => extendedDb = new ExtendedDatabase.ExtendedDatabase(persons));
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionWhenCountIsExceeded()
        {
            var n = 16;
            for (int i = 0; i < n; i++)
            {
                extendedDb.Add(new Person(i, $"Name: {i}"));
            }
            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(16, "Plamena")));
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionWhenUsernameAlreadyExist()
        {
            var name = "Pesho";
            extendedDb.Add(new Person(1, name));
            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(16, name)));
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionWhenIdAlreadyExist()
        {
            var id = 1;
            extendedDb.Add(new Person(id, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => extendedDb.Add(new Person(id, "Plamena")));
        }

        [Test]
        public void AddMethodShouldIncrementCountWhenAllIsValid()
        {
            var expectedCount = 2;
            extendedDb.Add(new Person(1, "Plamena"));
            extendedDb.Add(new Person(2, "Pesho"));
            Assert.That(extendedDb.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void RemoveMethodShouldThrowAnExceptionWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.Remove());
        }

        [Test]
        public void RemoveMethodShouldRemoveElementFromDb()
        {
            var n = 3;
            for (int i = 0; i < n; i++)
            {
                extendedDb.Add(new Person(i, $"Name: {i}"));
            }
            extendedDb.Remove();
            Assert.That(extendedDb.Count, Is.EqualTo(n - 1));
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindById((n - 1)));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void FindByUsernamMethodShouldThrowAnExceptionWhenUsernameIsInvalid(string username)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDb.FindByUsername(username));
        }

        [Test]
        public void FindByUsernameMethodShouldThrowAnExceptionWhenUsernameIsNotExisting()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindByUsername("fnuwifh"));
        }

        [Test]
        public void FindByUsernameMethodShouldReturnsTheCorrectResult()
        {
            var person = new Person(1, "Pesho");
            extendedDb.Add(person);
            var dbPerson = extendedDb.FindByUsername(person.UserName);
            Assert.That(person, Is.EqualTo(dbPerson));
        }

        [Test]

        public void FindByIdShouldThrowAnExceptionForInvalidId()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDb.FindById(123));
        }

        [Test]
        [TestCase(-1)]
        public void FindByIdShouldThrowAnExceptionWhenIdIsNegative(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDb.FindById(id));
        }

        [Test]
        public void FindByIdShouldReturnTheCorrectResult()
        {
            var person = new Person(1, "Pesho");
            extendedDb.Add(person);
            var dbPerson = extendedDb.FindById(person.Id);
            Assert.That(person, Is.EqualTo(dbPerson));
        }
    }
}