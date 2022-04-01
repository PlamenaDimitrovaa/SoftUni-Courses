using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        ComputerManager computerManager;
        Computer computer;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
            computer = new Computer("HP", "Model", 100);
        }

        [Test]
        public void ConstructorShouldInitializeListOfComputers()
        {
            Assert.IsNotNull(computerManager.Computers);
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionIfComputerAlreadyEsists()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer),
                "This computer already exists.");
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            computerManager.AddComputer(computer);
            Assert.AreEqual(1, computerManager.Computers.Count);
            computerManager.AddComputer(new Computer("Apple", "IMac", 500));
            Assert.AreEqual(2, computerManager.Computers.Count);
            computerManager.AddComputer(new Computer("Apple", "Bpp", 500));
            Assert.AreEqual(3, computerManager.Computers.Count);
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionIfComputerIsInvalid()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null),
                "Can not be null!");
        }

        [Test]
        public void RemoveComputerShouldThrowAnExceptionIfThereIsNoComputerWithThisManufacturerAndModel()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.RemoveComputer("Bo", "Pl"),
                "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void RemoveComputerShouldThrowAnExceptionIfThereIsNoComputerWithThisManufacturer()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null, "Model"),
                "Can not be null!");
        }

        [Test]
        public void RemoveComputerShouldThrowAnExceptionIfThereIsNoComputerWithThisModel()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer("HP", null),
                "Can not be null!");
        }

        [Test]
        public void RemoveComputerShouldWorkProperly()
        {
            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer("Apple", "IMac", 800));
            computerManager.RemoveComputer("Apple", "IMac");
            Assert.AreEqual(1, computerManager.Computers.Count);
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Apple", "IMac"),
                "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void RemoveComputerShouldReturnTheRightComputer()
        {
            computerManager.AddComputer(new Computer("Apple", "IMac", 800));
            computerManager.AddComputer(computer);
            Assert.AreEqual(computer, computerManager.RemoveComputer("HP", "Model"));
        }

        [Test]
        public void GetComputerShouldThrowAnExceptionIfThereIsNoThatComputer()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Pl", "Bo"),
                "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerShouldThrowAnExceptionIfManufacturerDoesntExists()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Pl", "Model"),
           "There is no computer with this manufacturer and model.");
        }


        [Test]
        public void GetComputerShouldThrowAnExceptionIfModelDoesntExists()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("HP", "Modela"),
           "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerShouldWorkProperly()
        {
            computerManager.AddComputer(computer);
            Assert.AreEqual(computer, computerManager.GetComputer("HP", "Model"));
        }

        [Test]
        public void GetComputerByManufacturerShouldThrowAnExceptionIfManufacturerDoesntExists()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null),
           "Can not be null!");
        }

        [Test]
        public void GetComputerByManufacturerShouldWorkProperly()
        {
            computerManager.AddComputer(computer);
            Computer computer2 = new Computer("HP", "Model2", 200);
            computerManager.AddComputer(computer2);
            List<Computer> computers = computerManager.Computers.Where(x => x.Manufacturer == "HP")
                .ToList();
            Assert.AreEqual(computerManager.Computers.Where(x => x.Manufacturer == "HP"), computers);
            Assert.AreEqual(computers, computerManager.GetComputersByManufacturer("HP"));
        }

        [Test]
        public void CountShouldWorkProperly()
        {
            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer("Lenovo", "AIP", 400));
            computerManager.AddComputer(new Computer("Samsung", "AB", 450));
            Assert.AreEqual(3, computerManager.Computers.Count);
        }

        [Test]
        public void CountShouldWorkCorrect()
        {
            computerManager.AddComputer(computer);
            Assert.AreEqual(1, computerManager.Count);
        }

        [Test]
        public void ComputersShouldBeReadOnly()
        {
            computerManager.AddComputer(computer);
            Computer computer2 = new Computer("HP", "Model2", 200);
            computerManager.AddComputer(computer2);
            List<Computer> computers = computerManager.Computers.Where(x => x.Manufacturer == "HP")
                .ToList();
            Assert.AreEqual(computerManager.Computers, computers.AsReadOnly());

        }
    }
}