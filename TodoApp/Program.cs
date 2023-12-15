using System;
using System.Runtime.CompilerServices;
public class Program {
    public static void Main(string[] args)
    {
        string action = (args.Length == 0) ? "" : args[0];

        var todoList = new TodoList();

        switch(action) 
        {
            case "add":
                string text = String.Join(" ", args[1..]);
                todoList.Add(text);
                break;
            case "complete":
                int index = int.Parse(args[1]);
                todoList.Complete(index);
                break;
            case "reset":
                todoList.Reset();
                break;
        }
        todoList.Show();
    }
}
