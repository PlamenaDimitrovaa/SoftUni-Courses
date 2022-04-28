using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    
    [TestFixture]
    public class SmartphoneShopTests
    {
        Shop shop;
        Smartphone phone;

        [SetUp]
        public void SettingUp()
        {
            shop = new Shop(100);
            phone = new Smartphone("Plamena", 100);
        }

        [Test]
        public void CtorShpultWorkCorrect()
        {
            Assert.AreEqual(100, shop.Capacity);
        }

        [Test]
        public void Capacity()
        {
            Assert.AreEqual(100, shop.Capacity);
        }

        [Test]
        public void Capacity2()
        {
            Assert.Throws<ArgumentException>(() => new Shop(-8), "Invalid capacity.");
        }

        [Test]
        public void Add()
        {
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("Plamena", 50)),
                $"The phone model Plamena already exist.");
        }

        [Test]
        public void Add2()
        {
            Shop shop2 = new Shop(2);
            shop2.Add(phone);
            shop2.Add(new Smartphone("Bo", 18));
            Assert.Throws<InvalidOperationException>(() => shop2.Add(new Smartphone("Mama", 20)),
                "The shop is full.");
        }

        [Test]
        public void Add3()
        {
            shop.Add(phone);
            Assert.AreEqual(1, shop.Count);
            shop.Add(new Smartphone("Bo", 18));
            Assert.AreEqual(2, shop.Count);
        }

        [Test]
        public void Count()
        {
            shop.Add(phone);
            Assert.AreEqual(1, shop.Count);
            shop.Add(new Smartphone("Bo", 18));
            Assert.AreEqual(2, shop.Count);
            shop.Add(new Smartphone("KAka", 15));
            Assert.AreEqual(3, shop.Count);
        }

        [Test]
        public void Remove()
        {
            Assert.Throws<InvalidOperationException>(() => shop.Remove(null),
            "The phone model null doesn't exist.");
        }

        [Test]
        public void Remove2()
        {
            shop.Add(phone);
            shop.Add(new Smartphone("kaka", 50));
            shop.Remove("kaka");
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void TestPhone()
        {
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("ods", 50),
                $"The phone model ods doesn't exist.");
        }

        [Test]
        public void TestPhone2()
        {
            shop.Add(phone);
            shop.TestPhone("Plamena", 100);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Plamena", 100),
                "The phone model Plamena is low on batery.");
        }

        [Test]
        public void TestPhone3()
        {
            shop.Add(phone);
            shop.TestPhone("Plamena", 20);
            Assert.AreEqual(80, phone.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhone()
        {
            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("kaka"),
                "The phone model kaka doesn't exist.");
        }

        [Test]
        public void ChargePhone2()
        {
            shop.Add(phone);
            shop.TestPhone("Plamena", 20);
            Assert.AreEqual(80, phone.CurrentBateryCharge);
            shop.ChargePhone("Plamena");
            Assert.AreEqual(100, phone.CurrentBateryCharge);
        }


    }
}