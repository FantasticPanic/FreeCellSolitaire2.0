using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveUndo : MonoBehaviour
{
    [SerializeField]
    Transform deck;
    [SerializeField]
    //private List<Move> commandList = new List<Move>();
    private Stack<ICommand> historyStack = new Stack<ICommand>();
    private int index;
    

    public void AddCommand(ICommand command)
    {
        //commandList.Add(command as Move);
        //command.Execute();
        command.Execute();
        historyStack.Push(command);
     
    }

    public void UndoCommand()
    {
        /*if (commandList.Count == 0)
            return;

                commandList[commandList.Count - 1].Undo();
                commandList.RemoveAt(commandList.Count - 1);      */

        if (historyStack.Count > 0)
        {
            historyStack.Pop().Undo();

        }
    }



    private void Start()
    {
        
    }
}
