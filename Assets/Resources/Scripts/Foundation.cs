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
        /*if (isAvailable == false)
        {
            userInput.PlaySound();
        }*/
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
                    heldCard.transform.position = this.transform.position;
                    interactable.oldCardPosition = interactable.gameObject.transform.position;
                    isAvailable = false;
                    other.transform.SetParent(this.transform);
                    interactable.onFoundation = true;
                    this.GetComponent<Collider>().isTrigger = false;
                   // userInput.PlaySound();
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
