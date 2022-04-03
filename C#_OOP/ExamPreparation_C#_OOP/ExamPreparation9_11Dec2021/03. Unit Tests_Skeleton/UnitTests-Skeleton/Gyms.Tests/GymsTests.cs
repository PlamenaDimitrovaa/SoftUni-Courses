using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        Gym gym;

        [SetUp]
        public void Setter()
        {
            gym = new Gym("Gym", 50);
        }

        [Test]
        public void CtorShouldWorkProperly()
        {
            Assert.AreEqual("Gym", gym.Name);
            Assert.AreEqual(50, gym.Capacity);
            gym.AddAthlete(new Athlete("Plamena"));
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void NameShouldThrowAnExceptionIfNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym("", 5), "Invalid gym name.");
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 5), "Invalid gym name.");

        }

        [Test]
        public void NameShouldWorkCorrect()
        {
            Gym gym2 = new Gym("Plamena", 10);
            Assert.AreEqual("Gym", gym.Name);
            Assert.AreEqual("Plamena", gym2.Name);
        }

        [Test]
        public void CapacityShouldThrowAnExceptionIfItIsBelow0()
        {
            Assert.Throws<ArgumentException>(() => new Gym("gym", -5), "Invalid gym capacity.");
        }

        [Test]
        public void CapacityShouldWorkCorrect()
        {
            var gym2 = new Gym("gym", 15);
            Assert.AreEqual(50, gym.Capacity);
            Assert.AreEqual(15, gym2.Capacity);
        }

        [Test]
        public void CountShouldWorkProperly()
        {
            gym.AddAthlete(new Athlete("Plamena"));
            Assert.AreEqual(1, gym.Count);
            gym.AddAthlete(new Athlete("Bo"));
            Assert.AreEqual(2, gym.Count);
            gym.AddAthlete(new Athlete("Vais"));
            Assert.AreEqual(3, gym.Count);
            gym.AddAthlete(new Athlete("Oreo"));
            Assert.AreEqual(4, gym.Count);
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionIfGymIsFull()
        {
            var gym2 = new Gym("gym", 2);
            gym2.AddAthlete(new Athlete("Plamena"));
            gym2.AddAthlete(new Athlete("Bo"));
            Assert.Throws<InvalidOperationException>(() => gym2.AddAthlete(new Athlete("Ori")), "The gym is full.");
        }

        [Test]
        public void AddMethodShouldWorkCorrect()
        {
            gym.AddAthlete(new Athlete("Pl"));
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowAnExceptionIfAthleteIsNull()
        {
            gym.AddAthlete(new Athlete("Pl"));
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Bo"),
                "The athlete Bo doesn't exist.");
        }

        [Test]
        public void RemoveMethodShouldWorkCorrect()
        {
            gym.AddAthlete(new Athlete("Pl"));
            gym.AddAthlete(new Athlete("Bo"));
            gym.AddAthlete(new Athlete("Ori"));
            Assert.AreEqual(3, gym.Count);
            gym.RemoveAthlete("Pl");
            Assert.AreEqual(2, gym.Count);
            gym.RemoveAthlete("Bo");
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void InjureAthleteShouldThrowAnExceptionIfRequestetAthleteDoesntExist()
        {
            gym.AddAthlete(new Athlete("Vais"));
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Bo"),
                "The athlete Bo doesn't exist.");
        }

        [Test]
        public void InjureAthleteShouldWorkCorrect()
        {
            var athlete1 = new Athlete("Plamena");
            gym.AddAthlete(athlete1);
            var athlete2 = new Athlete("Bo");
            gym.AddAthlete(athlete2);
            var athlete3 = new Athlete("Vais");
            gym.AddAthlete(athlete3);
            var athlete4 = new Athlete("Oreo");
            gym.AddAthlete(athlete4);
            gym.InjureAthlete("Plamena");
            gym.InjureAthlete("Bo");
            gym.InjureAthlete("Vais");
            gym.InjureAthlete("Oreo");
            Assert.AreEqual(true, athlete1.IsInjured);
            Assert.AreEqual(true, athlete2.IsInjured);
            Assert.AreEqual(true, athlete3.IsInjured);
            Assert.AreEqual(true, athlete4.IsInjured);
            Assert.AreEqual(athlete1, gym.InjureAthlete("Plamena"));
            Assert.AreEqual(athlete2, gym.InjureAthlete("Bo"));
            Assert.AreEqual(athlete3, gym.InjureAthlete("Vais"));
            Assert.AreEqual(athlete4, gym.InjureAthlete("Oreo"));
        }

        [Test]
        public void ReportShouldWorkCorrect()
        {
            var athlete1 = new Athlete("Plamena");
            gym.AddAthlete(athlete1);
            var athlete2 = new Athlete("Bo");
            gym.AddAthlete(athlete2);
            var athlete3 = new Athlete("Vais");
            gym.AddAthlete(athlete3);
            var athlete4 = new Athlete("Oreo");
            gym.AddAthlete(athlete4);
            Assert.AreEqual("Active athletes at Gym: Plamena, Bo, Vais, Oreo", gym.Report());
        }
    }
}
