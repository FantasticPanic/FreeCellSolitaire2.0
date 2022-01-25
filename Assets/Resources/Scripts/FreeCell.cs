﻿using System.Collections;
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
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAvailable == true)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
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
                heldCard.transform.position = this.transform.position;
                interactable.stackable = true;
                isAvailable = false;
               // userInput.Stack();
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
