using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Plamena", "itemld");
            bankVault.AddItem("A3", item);
        }

        [Test]
        public void AddItemShouldThrowAnExceptionIfCellDoesntExists()
        {
            Assert.Throws<ArgumentException>(() => 
            bankVault.AddItem("notExist", item), "Cell doesn't exists!");
        }

        [Test]
        public void AddItemShouldThrowAnExceptionIfCellIsAlreadyTaken()
        {
            var secondItem = new Item("Bo", "itemm");
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A3", secondItem), "Cell is already taken!");
        }

        [Test]
        public void AddItemShouldReturnTrueIfCellExists()
        {
            Assert.AreEqual(bankVault.VaultCells.ContainsKey("A3"), true);
        }

        [Test]
        public void AddItemShouldThrowAnExceptionIfItemIsAlreadyInCell()
        {
            Assert.Throws<InvalidOperationException>(() =>
            bankVault.AddItem("A1", item), "Item is already in cell!");
        }

        [Test]
        public void AddItemShouldWorkProperly()
        {
            var secondItem = new Item("Bo", "itemm");
            var result = bankVault.AddItem("A1", secondItem);
            Assert.AreEqual(secondItem, bankVault.VaultCells["A1"]);
            Assert.AreEqual(result, $"Item:{secondItem.ItemId} saved successfully!");
        }

        [Test]
        public void RemoveItemShouldThrowAnExceptionIfCellDoesntExists()
        {
            Assert.Throws<ArgumentException>(() =>
            bankVault.RemoveItem("BOBO", item), "Cell doesn't exists!");
        }

        [Test]
        public void RemoveItemShouldThrowAnExceptionIfItemInThatCellDoesntExists()
        {
            Assert.Throws<ArgumentException>(()
                => bankVault.RemoveItem("A1", item), "Item in that cell doesn't exists!");
        }

        [Test]
        public void RemoveItemShouldWorkProperly()
        {
            var result = this.bankVault.RemoveItem("A3", item);

            Assert.AreEqual(null, this.bankVault.VaultCells["A3"]);
            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }   
    }
}