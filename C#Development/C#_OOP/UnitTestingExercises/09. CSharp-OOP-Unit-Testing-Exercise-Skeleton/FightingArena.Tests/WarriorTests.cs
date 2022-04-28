
using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Plamena", 50, 70)]
        [TestCase("Niki", 67, 20)]
        [TestCase("Viktor", 10, 5)]
        [TestCase("Kiro", 1, 0)]

        public void ConstructorShouldSetEverythingIfDataIsValid(string name, int damage, int health)
        {
            Warrior warrior = new Warrior(name, damage, health);
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(health, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ConstructorShouldThrowArgumentExceptionForInvalidName(string name)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(name, 40, 50));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-54)]
        public void ConstructorShouldThrowArgumentExceptionForInvaliDamage(int damage)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior("Plamena", damage, 50));
        }

        [TestCase(-1)]
        [TestCase(-54)]
        public void ConstructorShouldThrowArgumentExceptionForInvalidHealth(int health)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior("Plamena", 60, health));
        }

        [TestCase("Plamena", 20, 50, "Niki", 40, 50)]
        [TestCase("Plamena", 30, 50, "Niki", 40, 50)]
        [TestCase("Plamena", 50, 50, "Niki", 30, 50)]
        [TestCase("Plamena", 50, 50, "Niki", 20, 50)]

        public void AttackMethodShouldThrowExceptionWhenHPIsBelowOrEqual30(string name, int health, int damage, 
            string enemyName, int enemyHealth, int enemyDamage)
        {
            Warrior warrior = new Warrior(name, damage, health);
            Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHealth);
            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(enemy));
        }

        [TestCase("Plamena", 50, 50, "Niki", 40, 90)]

        public void AttackMethodShouldThrowExceptionWhenOurHPIsBelowEnemyDamage(string name, int health, int damage,
           string enemyName, int enemyHealth, int enemyDamage)
        {
            Warrior warrior = new Warrior(name, damage, health);
            Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHealth);
            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(enemy));
        }


        [TestCase("Plamena", 50, 100, 50, 
            "Kiro", 50, 100, 50)]
        [TestCase("Plamena", 100, 100, 50,
            "Kiro", 50, 100, 0)]
        [TestCase("Plamena", 120, 100, 50,
            "Kiro", 50, 100, 0)]
        [TestCase("Plamena", 100, 100, 0,
            "Kiro", 100, 100, 0)]

        public void AttackMethodShouldReduceHPForWarriorAndEnemy(string name, int damage, int health, int resultHP,
            string enemyName, int enemyDamage, int enemyHealth, int resultEnemyHP)
        {
            Warrior warrior = new Warrior(name, damage, health);
            Warrior enemy = new Warrior(enemyName, enemyDamage, enemyHealth);
            warrior.Attack(enemy);
            Assert.AreEqual(resultHP, warrior.HP);
            Assert.AreEqual(resultEnemyHP, enemy.HP);
        }
    }
}