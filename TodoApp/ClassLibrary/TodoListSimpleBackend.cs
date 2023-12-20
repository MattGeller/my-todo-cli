public class TodoListSimpleBackend : ITodoListBackend
{
    private List<TodoItem> items = new List<TodoItem>();

    public TodoItem this[int index] => items[index];

    public void Add(string text)
    {
        items.Add(new TodoItem(text));
    }

    public void RemoveAt(int index)
    {
        items.RemoveAt(index);
    }

    public bool Any()
    {
        return items.Any();
    }

    public void Clear()
    {
        items.Clear();
    }

    public int Count()
    {
        return items.Count();
    }

}