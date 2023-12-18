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
            Assert.AreEqual($"0: {text}", actualOutput);
        }

        [Test]
        public void Reset()
        {
            // Arrange
            RunProgram("add", "Write C#");

            // Act
            string actualOutput = RunProgram("reset");

            // Assert
            Assert.AreEqual("Hooray! No Items", actualOutput);
        }

        [Test]
        [Ignore("Cannot work without persisting the todo list across runs")]
        public void Complete()
        {
            // Arrange
            RunProgram("add", "Write C#");

            // Act
            string actualOutput = RunProgram("complete", "0");

            // Assert
            Assert.AreEqual("Hooray! No Items", actualOutput);
        }

        private string RunProgram(string command, string text = "")
        {
            Program.Main([command, text]);
            string result = stringWriter.ToString().Trim();
            stringWriter.GetStringBuilder().Clear();
            return result;
        }
    }
}