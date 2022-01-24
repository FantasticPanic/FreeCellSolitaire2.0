using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foundation : MonoBehaviour
{
    [SerializeField]
    private GameObject heldCard;

    public bool isAvailable = true;

    Interactable interactable;

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

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Card")
        {
            Interactable interactable = other.gameObject.GetComponent<Interactable>();

            if (interactable.suit == foundationType.ToString())
            {


                if (isAvailable == true && interactable.isMouseDragged == false)
                {
                    //interactable bool should turn on here
                    heldCard = other.gameObject;
                    heldCard.transform.position = this.transform.position;
                    isAvailable = false;

                }
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
