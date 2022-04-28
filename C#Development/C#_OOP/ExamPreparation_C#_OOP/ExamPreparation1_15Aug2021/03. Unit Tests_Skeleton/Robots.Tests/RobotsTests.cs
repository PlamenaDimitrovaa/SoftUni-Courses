namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            var robot = new RobotManager(5);
            Assert.AreEqual(5, robot.Capacity);
        }

        [Test]
        public void EmptyRobotManagerShouldHaveCountOfZero()
        {
            var robots = new RobotManager(100);
            Assert.AreEqual(0, robots.Count);
        }

        [Test]
        public void CapacityPropertyShouldThrowAnExceptionIfValueIsZero()
        {
            Assert.That(() => new RobotManager(-1),
                Throws.ArgumentException);
        }

        [Test]
        public void CountPropertyShouldWorkProperly()
        {
            var robot1 = new Robot("Pesho", 2);
            var robot2 = new Robot("Gosho", 2);
            var robot3 = new Robot("Pl", 2);

            var robots = new RobotManager(100);
            robots.Add(robot1);
            robots.Add(robot2);
            robots.Add(robot3);
            Assert.AreEqual(3, robots.Count);
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionIfTherIsAlreadyARobotWithThisName()
        {
            var robots = new RobotManager(100);
            robots.Add(new Robot("Pl", 8));
            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("Pl", 100)));
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionIfCapacityIsReached()
        {
            var robots = new RobotManager(2);
            robots.Add(new Robot("Pl", 10));
            robots.Add(new Robot("Bo", 10));
            Assert.That(() => robots.Add(new Robot("AA", 50)), Throws.InvalidOperationException);

        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            var robots = new RobotManager(2);
            var robot1 = new Robot("Pl", 5);
            var robot2 = new Robot("Bo", 10);
            robots.Add(robot1);
            robots.Add(robot2);

            robots.Remove("Pl");
            Assert.AreEqual(1, robots.Count);
            robots.Remove("Bo");
            Assert.AreEqual(0, robots.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowAnExceptionIfRobotIsNull()
        {
            var robots = new RobotManager(2);
            robots.Add(new Robot("Pl", 5));
            Assert.Throws<InvalidOperationException>(() => robots.Remove("pl"));
        }

        [Test]
        public void WorkMethodShouldWorkCorrectly()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("Pl", 100);
            robots.Add(robot);
            robots.Work("Pl", "vet", 60);
            Assert.AreEqual(40, robot.Battery);
        }
        [Test]
        public void WorkMethodShouldThrowAnExceptionWhenRobotIsNotFound()
        {
            var robots = new RobotManager(2);
            robots.Add(new Robot("Pl", 8));
            Assert.Throws<InvalidOperationException>(() => robots.Work("pl", "vet", 3));
        }

        [Test]
        public void WorkMethodShouldThrowAnExceptionIfRobotBatteryIsLowerThanBatteryUsage()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("Pl", 5);
            Assert.Throws<InvalidOperationException>(() => robots.Work("Pl", "vet", 10));
        }

        [Test]
        public void ChargeMethodShouldThrowAnExceptionIfRobotIsNull()
        {
            var robots = new RobotManager(5);
            robots.Add(new Robot("Pl", 5));
            Assert.Throws<InvalidOperationException>(() => robots.Charge("Bo"));
        }

        [Test]
        public void ChargeMethodShouldWorkProperly()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("Pl", 100);
            robots.Add(robot);
            robots.Work("Pl", "vet", 60);
            robots.Charge("Pl");
            Assert.AreEqual(100, robot.Battery);
        }
    }
}
