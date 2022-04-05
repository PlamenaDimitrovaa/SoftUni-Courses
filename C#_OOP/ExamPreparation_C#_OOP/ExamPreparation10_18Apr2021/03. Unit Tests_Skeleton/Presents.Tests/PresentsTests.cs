namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        Bag bag;
        Present present;

        [SetUp]
        public void Setter()
        {
            bag = new Bag();
            present = new Present("Doll", 4);
        }

        [Test]
        public void PresentCtorShouldWorkCorrect()
        {
            Present present = new Present("Pl", 15);
            Assert.AreEqual("Pl", present.Name);
            Assert.AreEqual(15, present.Magic);
        }

        [Test]
        public void CreateShouldThrowAnExceptionIfPresentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null), "Present is null");
        }

        [Test]
        public void CreateShouldThrowAnExceptionIfPresentAreadyExists()
        {
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present), "This present already exists!");
        }

        [Test]
        public void CreateShouldWorkCorrect()
        {
            Assert.AreEqual("Successfully added present Doll.", bag.Create(present));
        }

        [Test]
        public void RemoveShouldWorkCorrect()
        {
            bag.Create(present);
            bag.Create(new Present("Pl", 5));
            var present2 = new Present("Bo", 10);
            Assert.AreEqual(true, bag.Remove(present));
            Assert.AreEqual(false, bag.Remove(present2));
        }

        [Test]
        public void GetPresentWithLeastMagicShouldWorkCorrect()
        {
            var present2 = new Present("Bo", 10);
            bag.Create(present);
            bag.Create(present2);
            Assert.AreEqual(present, bag.GetPresentWithLeastMagic());
           
        }

        [Test]
        public void GetPresentShouldWorkCorrect()
        {
            var present2 = new Present("Bo", 10);
            bag.Create(present);
            bag.Create(present2);
            Assert.AreEqual(present, bag.GetPresent("Doll"));
        }

        [Test]
        public void GetPresentShouldReturnNullIfItDoesntExists()
        {
            var present2 = new Present("Bo", 10);
            bag.Create(present);
            bag.Create(present2);
            Assert.AreEqual(null, bag.GetPresent("lp"));
        }

        [Test]
        public void GetPresentsShouldWorkCorrect()
        {
            var present2 = new Present("Bo", 10);
            bag.Create(present);
            bag.Create(present2);
            List<Present> presents = new List<Present>();
            presents.Add(present);
            presents.Add(present2);
            Assert.AreEqual(presents.AsReadOnly(), bag.GetPresents());
        }
    }
}
