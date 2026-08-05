using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private Stack<ICommand> undoHistory = new Stack<ICommand>();
    private Stack<ICommand> redoHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        undoHistory.Push(command);

        redoHistory.Clear();
    }

    public void UndoLastCommand()
    {
        if (undoHistory.Count == 0) return;

        ICommand last = undoHistory.Pop();

        last.Undo();

        redoHistory.Push(last);
    }

    public void RedoLastCommand()
    {
        if (redoHistory.Count == 0) return;

        ICommand command = redoHistory.Pop();

        command.Execute();

        undoHistory.Push(command);
    }

    public void ClearHistory()
    {
        undoHistory.Clear();
        redoHistory.Clear();
    }
}
