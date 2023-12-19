namespace TodoAppTest;

public class TodoListFileBackendTests
{
    protected TodoListFileBackend? backend;
    public class WhenTheListIsEmpty : TodoListFileBackendTests
    {
        [SetUp]
        public void SetupEmptyFile()
        {
            backend = new TodoListFileBackend("empty-list.txt");
            backend.Clear();
        }

        [Test]
        public void Any_returns_false()
        {
            Assert.IsFalse(backend.Any());
        }

        [Test]
        public void Count_returns_0()
        {
            Assert.AreEqual(0, backend.Count());
        }

        [Test]
        public void Add_increases_the_count()
        {
            backend.Add("Learn C#");
            Assert.AreEqual(1, backend.Count());
        }
    }

    public class WhenTheListIsNotEmpty : TodoListFileBackendTests
    {
        [SetUp]
        public void SetupNonEmptyFile()
        {
            backend = new TodoListFileBackend("nonempty-list.txt");
            backend.Clear();
            backend.Add("Learn C#");
            backend.Add("Write tests");
        }

        [Test]
        public void Any_returns_true()
        {
            Assert.That(backend.Any(), Is.True);
        }

        [Test]
        public void Count_returns_2()
        {
            Assert.That(backend.Count(), Is.EqualTo(2));
        }

        [Test]
        public void RemoveAt_decreases_the_count()
        {
            backend.RemoveAt(0);
            Assert.That(backend.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Clear_sets_the_count_to_0()
        {
            backend.Clear();
            Assert.That(backend.Count(), Is.EqualTo(0));
        }
    }
}