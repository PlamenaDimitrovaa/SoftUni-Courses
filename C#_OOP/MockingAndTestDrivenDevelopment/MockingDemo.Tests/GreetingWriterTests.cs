using MockingAndTestDrivenDevelopment;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockingDemo.Tests
{
    [TestFixture]
   public class GreetingWriterTests
    {
        [Test]
        public void WriteGreetingShouldWorkCorrectlyInTheMorning()
        {
            var memory = new MemoryWriter();
            var writer = new GreetingWriter(memory);
            writer.WriteGreeting(new DateTime(2021, 1, 1, 8, 0, 0));
            Assert.True(memory.ToString().Contains("morning"));
        }

        [Test]
        public void WriteGreetingShouldWorkCorrectlyInTheAfternoon()
        {
            var memory = new MemoryWriter();
            var writer = new GreetingWriter(memory);
            writer.WriteGreeting(new DateTime(2021, 1, 1, 15, 0, 0));
            Assert.True(memory.ToString().Contains("afternoon"));
        }

        [Test]
        public void WriteGreetingShouldWorkCorrectlyInTheEvening()
        {
            var memory = new MemoryWriter();
            var writer = new GreetingWriter(memory);
            writer.WriteGreeting(new DateTime(2021, 1, 1, 20, 0, 0));
            Assert.True(memory.ToString().Contains("evening"));
        }

        class MemoryWriter : IWriter
        {
            private StringBuilder sb = new StringBuilder();
            public void Write(string text)
            {
                sb.AppendLine(text);
            }
            public override string ToString()
            {
                return sb.ToString().TrimEnd();
            }
        }
    }
}
