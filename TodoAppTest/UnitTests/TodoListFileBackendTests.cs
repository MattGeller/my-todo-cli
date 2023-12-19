namespace TodoAppTest;

public class TodoListFileBackendTests
{
    private TodoListFileBackend emptyFileBackend;
    private TodoListFileBackend nonEmptyFileBackend;

    [SetUp]
    public void SetupEmptyFile()
    {
        emptyFileBackend = new TodoListFileBackend("empty-list.txt");
        emptyFileBackend.Clear();
    }

    [SetUp]
    public void SetupNonEmptyFile()
    {
        nonEmptyFileBackend = new TodoListFileBackend("nonempty-list.txt");
        nonEmptyFileBackend.Clear();
        nonEmptyFileBackend.Add("Learn C#");
        nonEmptyFileBackend.Add("Write tests");
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

    [Test]
    public void TestEmptyFile_Add()
    {
        emptyFileBackend.Add("Learn C#");
        Assert.AreEqual(1, emptyFileBackend.Count());
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

    [Test]
    public void TestNonEmptyFile_RemoveAt()
    {
        nonEmptyFileBackend.RemoveAt(0);
        Assert.AreEqual(1, nonEmptyFileBackend.Count());
    }

    [Test]
    public void TestNonEmptyFile_Clear()
    {
        nonEmptyFileBackend.Clear();
        Assert.AreEqual(0, nonEmptyFileBackend.Count());
    }
}