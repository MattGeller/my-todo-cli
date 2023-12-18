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
            string actualOutput = RunProgram(command);

            // Assert
            Assert.AreEqual("Hooray! No Items", actualOutput);
        }

        [Test]
        public void Add()
        {
            // Arrange
            var command = "add";
            var text = "Learn C#";

            // Act
            string actualOutput = RunProgram(command, text);

            // Assert
            Assert.AreEqual("0: Learn C#", actualOutput);
        }

        private string RunProgram(string command, string text = "")
        {
            Program.Main([command, text]);
            return stringWriter.ToString().Trim();
        }
    }
}