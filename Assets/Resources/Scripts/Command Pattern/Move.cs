using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : ICommand
{
    [SerializeField]
    private Vector3 newPosition;
    private Transform oldPosition;
    private GameObject c2;
    private GameObject c1;
    private GameObject slot;
    float yOffset = 50.0f;
    float xOffset = 15.0f;


    public Move(GameObject c1, Vector3 newPosition, GameObject c2, Transform oldPosition)
    {
        this.newPosition = newPosition;
        this.c1 = c1;
        this.oldPosition = oldPosition;
        this.c2 = c2;
    }




    public void Execute()
    { 
        c1.gameObject.transform.position = new Vector3(c2.transform.position.x + xOffset, c2.transform.position.y - yOffset,
                  1);

    }

    public void Undo()
    {

        c1.gameObject.transform.position = new Vector3(c1.GetComponent<Interactable>().oldCardPosition.x  
            ,c1.transform.GetComponent<Interactable>().oldCardPosition.y, 1);
        c1.transform.SetAsLastSibling();
        c1.transform.SetParent(c1.GetComponent<Interactable>().oldCardParent);
      
    }

}
