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
    PointerEventData eventData;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Card")
        {
            Interactable interactable = other.gameObject.GetComponent<Interactable>();
           
            
            if (isAvailable == true)
            {
                //interactable bool should turn on here
                heldCard = other.gameObject;
                heldCard.transform.position = this.transform.position;
                print("space available");
                interactable.OnPointerUp(eventData);
                isAvailable = false;
                
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
