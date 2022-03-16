namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            var aquarium = new Aquarium("Aquarium", 5);
            var listFish = new List<Fish>();
            Assert.AreEqual(5, aquarium.Capacity);
            Assert.AreEqual("Aquarium", aquarium.Name);
            Assert.IsNotNull(listFish);
        }

        [Test]
        public void NamePropertyShouldThrowAnExceptionIfNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, 5), "Invalid aquarium name!");
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 5), "Invalid aquarium name!");
        }

        [Test]
        public void NamePropertyShouldWorkProperly()
        {
            var aquarium = new Aquarium("Aquarium", 5);
            Assert.AreEqual("Aquarium", aquarium.Name);
        }

        [Test]
        public void CapacityPropertyShouldThrowAnExceptionIfCapacityIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Aquarium", -1),
                "Invalid aquarium capacity!");
        }

        [Test]
        public void CapacityPropertyShouldWorkProperly()
        {
            var aquarium = new Aquarium("Aquarium", 5);
            Assert.AreEqual(5, aquarium.Capacity);
        }

        [Test]
        public void CountPropShouldWorkProperly()
        {
            var aquarium = new Aquarium("Aquarium", 1);
            var fish1 = new Fish("Riba");
            aquarium.Add(fish1);
            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]

        public void AddMethodShouldThrowAnExceptionIfCountIsEqualToCapacity()
        {
            var aquarium = new Aquarium("Aquarium", 1);

            var fish1 = new Fish("Riba");
            var fish2 = new Fish("Riba2");
            aquarium.Add(fish1);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish2), "Aquarium is full!");
        }

        [Test]
        public void AddMethodShouldWorkProperly()
        {
            var aquarium = new Aquarium("Aquarium", 2);

            var fish1 = new Fish("Riba");
            var fish2 = new Fish("Riba2");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Assert.AreEqual(2, aquarium.Count);
        }

        [Test]
        public void RemoveFishMethodShouldWorkProperly()
        {
            var aquarium = new Aquarium("Aquarium", 2);

            var fish1 = new Fish("Riba");
            var fish2 = new Fish("Riba2");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.RemoveFish("Riba");
            Assert.AreEqual(1, aquarium.Count);

        }

        [Test]
        public void RemoveFishMethodShouldThrowAnExceptionIsNameDoesntExists()
        {
            var aquarium = new Aquarium("Aquarium", 2);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(null));
        }

        [Test]
        public void SellFishMethodShouldWorkProperly()
        {
            var aquarium = new Aquarium("Aquarium", 2);

            var fish1 = new Fish("Riba");
            var fish2 = new Fish("Riba2");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Fish fish = aquarium.SellFish("Riba");
            Assert.AreEqual(fish.Name, "Riba");
            Assert.AreEqual(fish.Available, false);

        }

        [Test]
        public void SellFishMethodShouldThrowAnExceptionIfFishDoesntExists()
        {
            var aquarium = new Aquarium("Aquarium", 2);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));
        }

        [Test]
        public void ReportMethodShouldWorkProperly()
        {
            var aquarium = new Aquarium("Aquarium", 2);
            aquarium.Add(new Fish("Pl"));
            aquarium.Add(new Fish("Bo"));
            Assert.AreEqual("Fish available at Aquarium: Pl, Bo", aquarium.Report());
        }
    }
}
