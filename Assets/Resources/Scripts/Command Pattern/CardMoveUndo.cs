using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveUndo : MonoBehaviour
{
    [SerializeField]
    private List<Move> commandList = new List<Move>();
    private int index;

    public void AddCommand(ICommand command)
    {
        commandList.Add(command as Move);
        command.Execute();
        index++;
    }

    public void UndoCommand()
    {
        if (commandList.Count == 0)
            return;
        if (index > 0)
            {
                commandList[commandList.Count - 1].Undo();
                commandList.RemoveAt(commandList.Count - 1);
                index--;
            }
    }

    private IEnumerator DoMovesOverTime()
    {
        foreach (Move move in commandList)
        {
            move.Execute();

            yield return new WaitForSeconds(0.1f);
        }
    }
    
}
