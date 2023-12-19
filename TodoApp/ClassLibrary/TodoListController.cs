public class TodoListController
{
    public ITodoListBackend Backend;

    public TodoListController(ITodoListBackend backend)
    {
        Backend = backend;
    }

    public void Show()
    {
        if (!Backend.Any())
        {
            Console.WriteLine("Hooray! No Items");
            return;
        }
        for (int i = 0; i < Backend.Count(); i++)
        {
            Console.WriteLine($"{i}: {Backend[i].Text}");
        }
    }
    public void Add(string text)
    {
        Backend.Add(text);
    }
    public void Complete(int index)
    {
        Backend.RemoveAt(index);
    }
    public void Reset()
    {
        Backend.Clear();
    }
}