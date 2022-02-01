using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : ICommand
{
    [SerializeField]
    private Vector3 newPosition;
    private Transform oldPosition;
    private GameObject newParent;
    private GameObject objectToMove;

    public Move(GameObject objectToMove, Vector3 newPosition, GameObject newParent, Transform oldPosition)
    {
        this.newPosition = newPosition;
        this.newParent = newParent;
        this.oldPosition = oldPosition;
        this.objectToMove = objectToMove;
    }

    public void Execute()
    {
        oldPosition.position = newPosition;
        objectToMove.transform.SetParent(newParent.transform.parent);
    }

    public void Undo()
    {
        oldPosition.position = oldPosition.position;
        objectToMove.transform.SetParent(GameObject.Find("Deck (1)").transform);


    }
    // Start is called before the first frame update

}
