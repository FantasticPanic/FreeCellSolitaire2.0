using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FreeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject heldCard;

    public bool isAvailable = true;

    Interactable interactable;
    UserInput userInput;
    PointerEventData eventData;
    CardMoveUndo cardMoveUndo;


    // Start is called before the first frame update
    void Start()
    {
        userInput = GameObject.Find("GameManager").GetComponent<UserInput>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Card" && isAvailable == true)
        {
            Interactable interactable = other.gameObject.GetComponent<Interactable>();
            interactable.stackable = true;
            
            if ( interactable.isMouseDragged == false)
            {
                //interactable bool should turn on here
                heldCard = other.gameObject;
                isAvailable = false;
                userInput.SendMoveCommand(other.gameObject, other.gameObject.transform.position, this.gameObject, other.gameObject.transform);
                //centers the card in the foundation slot
                other.transform.position = new Vector3(other.transform.position.x - 15.0f, other.transform.position.y + 50.0f, 1);
                other.transform.SetParent(this.transform);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Card")
        {
            if (isAvailable == false)
            {
                heldCard = null;
                isAvailable = true;
            }
        }
    }

}
