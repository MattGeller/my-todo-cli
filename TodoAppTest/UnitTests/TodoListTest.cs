namespace TodoAppTest;

public class Tests
{
    private TodoListController todoListController;

    [SetUp]
    public void Setup()
    {
        todoListController = new TodoListController();
    }

    [Test]
    public void Show() {
        todoListController.Add("Eat");
        todoListController.Add("Sleep");
        todoListController.Add("Dream");

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        todoListController.Show();

        Assert.IsTrue(stringWriter.ToString().Contains("Eat"));
        Assert.IsTrue(stringWriter.ToString().Contains("Sleep"));
        Assert.IsTrue(stringWriter.ToString().Contains("Dream"));
    }

    [Test]
    public void Add()
    {
        string itemText = "Learn C#";
        todoListController.Add(itemText);

        Assert.That(todoListController.Items.Count, Is.EqualTo(1));
        Assert.That(todoListController.Items[0].Text, Is.EqualTo(itemText));
    }

    [Test]
    public void Reset()
    {
        todoListController.Add("Write C#");
        todoListController.Add("Dream about C#");

        todoListController.Reset();
        Assert.That(todoListController.Items.Count, Is.EqualTo(0));
    }

    [Test]
    public void Complete()
    {
        todoListController.Add("Write C#");
        todoListController.Add("Dream about C#");
        todoListController.Complete(0);

        Assert.That(todoListController.Items[0].Text, Is.EqualTo("Dream about C#"));
    }
}