namespace TodoAppTest;

public class TodoListFileBackendTests
{
    public class WhenTheListIsEmpty
    {
        private TodoListFileBackend emptyFileBackend;

        [SetUp]
        public void SetupEmptyFile()
        {
            emptyFileBackend = new TodoListFileBackend("empty-list.txt");
            emptyFileBackend.Clear();
        }

        [Test]
        public void TestEmptyFile_Any()
        {
            Assert.IsFalse(emptyFileBackend.Any());
        }

        [Test]
        public void TestEmptyFile_Count()
        {
            Assert.AreEqual(0, emptyFileBackend.Count());
        }
    }

    public class WhenTheListIsNotEmpty
    {
        private TodoListFileBackend nonEmptyFileBackend;

        [SetUp]
        public void SetupNonEmptyFile()
        {
            nonEmptyFileBackend = new TodoListFileBackend("nonempty-list.txt");
            nonEmptyFileBackend.Clear();
            nonEmptyFileBackend.Add("Learn C#");
            nonEmptyFileBackend.Add("Write tests");
        }

        [Test]
        public void TestNonEmptyFile_Any()
        {
            Assert.IsTrue(nonEmptyFileBackend.Any());
        }

        [Test]
        public void TestNonEmptyFile_Count()
        {
            Assert.AreEqual(2, nonEmptyFileBackend.Count());
        }
    }
}