public interface ITodoListBackend
{
    bool Any();
    
    // this makes angle bracket syntax usable
    TodoItem this[int index] { get; }

    int Count();

    void Add(string text);

    void RemoveAt(int index);
    
    void Clear();
}