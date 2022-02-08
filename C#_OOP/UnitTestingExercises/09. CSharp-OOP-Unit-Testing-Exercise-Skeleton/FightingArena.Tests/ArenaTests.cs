using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeAllValues()
        {
            Arena arena = new Arena();
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollMethodShouldAddWarriorIfItDoesntExist()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Plamena", 50, 80);
            Warrior warrior2 = new Warrior("Plamena2", 150, 280);
            Warrior warrior3 = new Warrior("Plamena3", 350, 480);

            arena.Enroll(warrior);
            arena.Enroll(warrior2);
            arena.Enroll(warrior3);

            Assert.AreEqual(3, arena.Count);
            bool warriorExist = arena.Warriors.Contains(warrior);
            bool warrior2Exist = arena.Warriors.Contains(warrior2);
            bool warrior3Exist = arena.Warriors.Contains(warrior3);

            Assert.True(warriorExist);
            Assert.True(warrior2Exist);
            Assert.True(warrior3Exist);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionForDublicateWarrior()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Plamena", 50, 80);

            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidWarrior()
        {
            Arena arena = new Arena();
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Kiro", "Plamena"),
                "There is no fighter with name enrolled for the fights!");
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidAttacker()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Plamena", 40, 70);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Kiro", "Plamena"), 
                "There is no fighter with name Kiro enrolled for the fights!");
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidDefender()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Kiro", 40, 70);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Kiro", "Plamena"),
                "There is no fighter with name Plamena enrolled for the fights!");
        }

        [Test]
        public void FightShouldReduceHP()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Plamena", 100, 50);
            Warrior defender = new Warrior("Kiro", 40, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight("Plamena", "Kiro");

            Warrior warriorAttacker = arena.Warriors.FirstOrDefault(x => x.Name == "Plamena");
            Warrior warriorDefender = arena.Warriors.FirstOrDefault(x => x.Name == "Kiro");

            Assert.AreEqual(10, warriorAttacker.HP);
            Assert.AreEqual(0, warriorDefender.HP);
        }
    }
}
