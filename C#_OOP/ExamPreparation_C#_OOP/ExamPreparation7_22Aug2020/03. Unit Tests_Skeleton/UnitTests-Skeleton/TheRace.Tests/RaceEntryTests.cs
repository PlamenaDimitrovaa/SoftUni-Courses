using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        RaceEntry raceEntry;
        UnitCar car;
        UnitDriver driver;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            car = new UnitCar("BMW", 163, 3000);
            driver = new UnitDriver("Plamena", new UnitCar("BMW", 163, 3000));
        }

        [Test]
        public void AddDriverMethodShouldThrowAnExceptionIfDriverIsInvalid()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null),
                "Driver cannot be null.");
        }

        [Test]
        public void AddDriverShouldThrowAnExceptionIfDriverExists()
        {
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver),
               "Driver Plamena is already added.");
        }

        [Test]
        public void AddDriverShouldWorkProperly()
        {
            raceEntry.AddDriver(driver);
            Assert.AreEqual(1, raceEntry.Counter);
            raceEntry.AddDriver(new UnitDriver("Bo", new UnitCar("Mercedes", 120, 4000)));
            Assert.AreEqual(2, raceEntry.Counter);
        }

        [Test]
        public void AddDriverShouldReturnTheCorrectMessage()
        {
            Assert.AreEqual("Driver Plamena added in race.", raceEntry.AddDriver(driver));
        }

        [Test]
        public void CounterShouldWorkProperly()
        {
            raceEntry.AddDriver(driver);
            Assert.AreEqual(1, raceEntry.Counter);
            raceEntry.AddDriver(new UnitDriver("Bo", new UnitCar("Mercedes", 120, 4000)));
            Assert.AreEqual(2, raceEntry.Counter);
        }

        [Test]
        public void CalculateMethodShouldThrowAnException()
        {
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower(),
                "The race cannot start with less than 2 participants.");
        }

        [Test]
        public void CalculateMethodShouldWorkProperly()
        {
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(new UnitDriver("Bo", new UnitCar("Mercedes", 120, 4000)));
            Assert.AreEqual(141.5, raceEntry.CalculateAverageHorsePower());
        }
    }
}