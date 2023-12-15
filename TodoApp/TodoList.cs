public class TodoList
{
    public List<TodoItem> Items = new List<TodoItem>();

    public void Show()
    {
        if (!Items.Any())
        {
            Console.WriteLine("Hooray! No Items");
            return;
        }
        for (int i = 0; i < Items.Count; i++)
        {
            Console.WriteLine($"{i}: {Items[i].Text}");
        }
    }
    public void Add(string text)
    {
        Items.Add(new TodoItem(text));
    }
    public void Complete(int index)
    {
        Items.RemoveAt(index);
    }
    public void Reset()
    {
        Items.Clear();
    }
}