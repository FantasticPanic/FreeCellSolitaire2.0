using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : ICommand
{
    [SerializeField]
    private Vector3 newPosition;
    private Transform oldPosition;
    private Interactable c2;
    private Interactable c1;
    float yOffset = 50.0f;
    float xOffset = 15.0f;

    public Move(Interactable c1, Vector3 newPosition, Interactable c2, Transform oldPosition)
    {
        this.newPosition = newPosition;
        this.c1 = c1;
        this.oldPosition = oldPosition;
        this.c2 = c2;
    }

    public void Execute()
    {
        //oldPosition.position = newPosition;
        //objectToMove.transform.SetParent(newParent.transform.parent);

        c1.gameObject.transform.position = new Vector3(c2.transform.position.x + xOffset, c2.transform.position.y - yOffset,
                  1);

        //c1.row = c2.row;
        c1.transform.SetParent(c2.transform.parent);
    }

    public void Undo()
    {
        //   oldPosition.position = oldPosition.position;
        // c1.transform.SetParent(GameObject.Find("Deck (1)").transform);

        //c1.gameObject.transform.position = new Vector3(c2.transform.position.x + xOffset, c2.transform.position.y - yOffset,
        //        1);
       // c1.stackable = true;
        c1.gameObject.transform.position = new Vector3(c1.oldCardPosition.x , c1.oldCardPosition.y,
                 1);
        c1.transform.SetAsLastSibling();
        c1.transform.SetParent(c1.oldCardParent);
       


    }
    // Start is called before the first frame update

}
