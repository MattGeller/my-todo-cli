using System;
using System.Runtime.CompilerServices;
public class Program {
    public static void Main(string[] args)
    {
        string action = (args.Length == 0) ? "" : args[0];

        var backend = new TodoListFileBackend("my-list.txt");
        var todoListController = new TodoListController(backend);

        switch(action) 
        {
            case "add":
                string text = String.Join(" ", args[1..]);
                todoListController.Add(text);
                break;
            case "complete":
                int index = int.Parse(args[1]);
                todoListController.Complete(index);
                break;
            case "reset":
                todoListController.Reset();
                break;
        }
        todoListController.Show();
    }
}
