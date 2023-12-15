public interface ITodoItem
{
    string Text { get; set; }
}

public class TodoItem : ITodoItem
{
    public string Text { get; set; } = "";
    public TodoItem(string text)
    {
        Text = text;
    }
}