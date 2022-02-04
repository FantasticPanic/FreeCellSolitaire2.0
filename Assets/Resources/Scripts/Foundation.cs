using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foundation : MonoBehaviour
{
    [SerializeField]
    private GameObject heldCard;

    public bool isAvailable = true;

    Interactable interactable;
    UserInput userInput;

    public enum FoundationType
    {
        C,
        S,
        D,
        H,
    }

    public FoundationType foundationType;

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
            

            if (interactable.suit == foundationType.ToString() && interactable.value == 1)
            {
                interactable.stackable = true;

                if (isAvailable == true && interactable.isMouseDragged == false)
                {
                    //interactable bool should turn on here
                    heldCard = other.gameObject;
                    isAvailable = false;
                    other.transform.SetParent(this.transform);
                    interactable.onFoundation = true;
                    this.GetComponent<Collider>().isTrigger = false;
                    userInput.SendMoveCommand(other.gameObject, other.gameObject.transform.position, this.gameObject, other.gameObject.transform);
                    //centers the card in the foundation slot
                    other.transform.position = new Vector3(other.transform.position.x - 15.0f, other.transform.position.y + 50.0f, 1);
                }
            }
        }

    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Card")
        {
            Interactable interactable = other.gameObject.GetComponent<Interactable>();

            if (isAvailable == false)
            {
                heldCard = null;               
                isAvailable = true;
                interactable.onFoundation = false;
            }
        }
    }
}
