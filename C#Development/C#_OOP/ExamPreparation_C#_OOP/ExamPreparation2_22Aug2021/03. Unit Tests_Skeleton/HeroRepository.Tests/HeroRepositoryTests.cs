using System;
using System.Collections.Generic;
using NUnit.Framework;


[TestFixture]
public class HeroRepositoryTests
{
    private HeroRepository heroRep;

    [SetUp]
    public void SetUp()
    {
        heroRep = new HeroRepository();
    }

    [Test]
    public void CtorShouldWorkCorrectly()
    {
        Assert.IsNotNull(heroRep.Heroes);
    }

    [Test]
    public void CreateMethodShouldThrowAnExceptionIfHeroIsNotInitialized()
    {
        Assert.Throws<ArgumentNullException>(() => heroRep.Create(null));
    }

    [Test]
    public void CreateMethodShouldThrowAnExceptionIfTheHeroAlreadyExists()
    {
        var hero1 = new Hero("Pl", 50);
        heroRep.Create(hero1);
        Assert.Throws<InvalidOperationException>(() => heroRep.Create(hero1));
    }

    [Test]
    public void CreateMethodShouldWorkCorrectly()
    {
        var hero1 = new Hero("Pl", 50);
        var message = heroRep.Create(hero1);
        Assert.AreEqual(message, "Successfully added hero Pl with level 50");
    }

    [TestCase(" ")]
    [TestCase(null)]
    public void RemoveMethodShouldThrowAnExceptionIfTheNameIsNullOrWhiteSpace(string name)
    {
        Assert.Throws<ArgumentNullException>(() => heroRep.Remove(name));
    }

    [Test]
    public void RemoveMethodShouldWorkCorrectly()
    {
        var hero1 = new Hero("Pl", 50);
        var hero2 = new Hero("Bo", 100);
        heroRep.Create(hero1);
        heroRep.Create(hero2);
        heroRep.Remove("Pl");
        Assert.AreEqual(1, heroRep.Heroes.Count);
        heroRep.Remove("Bo");
        Assert.AreEqual(0, heroRep.Heroes.Count);
    }

    [Test]
    public void GetHeroWithHighestLevelMethodShouldWorkCorrectly()
    {
        var hero1 = new Hero("Pl", 50);
        var hero2 = new Hero("Bo", 100);
        heroRep.Create(hero1);
        heroRep.Create(hero2);
        Assert.AreEqual(hero2, heroRep.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroMethodShouldWorkCorrectly()
    {
        var hero0 = new Hero("Plamena", 50);
        var hero1 = new Hero("Boyana", 80);
        var hero2 = new Hero("Liliya", 100);
        heroRep.Create(hero0);
        heroRep.Create(hero1);
        heroRep.Create(hero2);
        Assert.AreSame(hero0, heroRep.GetHero("Plamena"));
    }
}