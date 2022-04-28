namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        Book book;

        [SetUp]
        public void Setting()
        {
            book = new Book("Kniga", "Pl");
            Dictionary<int, string> footnote = new Dictionary<int, string>();
        }

        [Test]
        public void BookNameShouldThrowAnExceptionIfNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("", "Plamena"), $"Invalid {""}!");
            Assert.Throws<ArgumentException>(() => new Book(null, "Plamena"), $"Invalid {null}!");
        }

        [Test]
        public void BookNameShouldWorkProperly()
        {
            var book = new Book("Kniga", "Pl");
            Assert.AreEqual("Kniga", book.BookName);
        }

        [Test]
        public void AuthorShouldThrowAnExceptionIfItIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("Pl", ""), $"Invalid {""}!");
            Assert.Throws<ArgumentException>(() => new Book("Plamena", null), $"Invalid {null}!");
        }

        [Test]
        public void AuthorShouldWorkProperly()
        {
            var book = new Book("Kniga", "Pl");
            Assert.AreEqual("Pl", book.Author);
        }

        [Test]
        public void AddFootnoteShouldThrowAnExceptionIfFootnoteNumberAlreadyExists()
        {
            book.AddFootnote(1, "Kniga");
            Assert.Throws<InvalidOperationException>(() => 
            book.AddFootnote(1, "Kniga"), "Footnote already exists!");
        }

        [Test]
        public void AddFootnoteShouldWorkProperly()
        {
            book.AddFootnote(1, "Pl");
            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void FindFootnoteShouldThrowAnExceptionIfItDoesntExists()
        {
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(1));
        }

        [Test]
        public void FindFootnoteShouldWorkProperly()
        {
           book.AddFootnote(1, "Pl");
           var text = book.FindFootnote(1);
            Assert.AreEqual("Footnote #1: Pl", text);
        }

        [Test]
        public void AlterFootnoteShouldThrowAnExceptionIfFootnoteDoesntExists()
        {
            Assert.Throws<InvalidOperationException>(()
                => book.AlterFootnote(1, "Pl"), "Footnote does not exists!");
        }

        [Test]
        public void AlterFootnoteShouldWorkProperly()
        {
            book.AddFootnote(1, "Plamena");
            book.AlterFootnote(1, "Pl");
            var neededBook = book.FindFootnote(1);
            Assert.AreEqual("Footnote #1: Pl", neededBook);
        }
    }
}