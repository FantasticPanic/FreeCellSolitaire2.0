using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : ICommand
{
    [SerializeField]
    private Vector3 newPosition;
    private Transform oldPosition;
    private GameObject newParent;

    public Move(Vector3 newPosition, GameObject newParent, Transform oldPosition)
    {
        this.newPosition = newPosition;
        this.newParent = newParent;
        this.oldPosition = oldPosition;
    }

    public void Execute()
    {
        oldPosition.position = newPosition;
        oldPosition.transform.SetParent(newParent.transform.parent);
    }

    public void Undo()
    {
        oldPosition.position = oldPosition.position;
        oldPosition.transform.SetParent(oldPosition.transform.parent);

    }
    // Start is called before the first frame update

}
