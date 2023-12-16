using NUnit.Framework;
using System;
using System.IO;

namespace TodoAppTest
{
    public class ApplicationTest
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        [SetUp]
        public void Setup()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        [TearDown]
        public void Cleanup()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }

        [Test]
        public void Show()
        {
            // Arrange
            var command = "show";

            // Act
            Program.Main(new[] { command });

            // Assert
            string actualOutput = stringWriter.ToString().Trim();
            Assert.AreEqual("Hooray! No Items", actualOutput);
        }
    }
}