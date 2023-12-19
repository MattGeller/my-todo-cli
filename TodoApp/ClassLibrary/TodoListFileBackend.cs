public class TodoListFileBackend : ITodoListBackend
{
    private string filePath;
    private List<TodoItem> items = new List<TodoItem>();

    public TodoListFileBackend(string path)
    {
        filePath = path;
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        Read();
    }

    public TodoItem this[int index] => items[index];

    public void Read()
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                items.Add(new TodoItem(line));
            }
        }
    }

    public void Add(string text)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(text);
        }
        Refresh();
    }

    public void Refresh()
    {
        items.Clear();
        Read();
    }

    public bool Any()
    {
        return items.Any();
    }

    public void Clear()
    {
        File.WriteAllText(filePath, "");
        Refresh();
    }

    public int Count()
    {
        return items.Count();
    }

    public void RemoveAt(int index)
    {
        items.RemoveAt(index);
        ReWrite();
    }

    private void ReWrite()
    {
        File.WriteAllText(filePath, "");
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach (TodoItem item in items)
            {
                writer.WriteLine(item.Text);
            }
        }
    }
}