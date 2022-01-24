using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UserInput : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;
    private CardManager cardManager;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //function for anytime a card gets clicked
    public void Card(GameObject selected)
    {
        //set card1 as the selected card
        card1 = selected;
        
         if (card1 != selected)
        {
            if (Stackable(selected))
            {
                Stack(selected);
            }
            else
            {
                card1 = selected;
            }
        }
       
    }


    public bool Stackable(GameObject selected)
    {
        Interactable c1 = card1.GetComponent<Interactable>();
        Interactable c2 = selected.GetComponent<Interactable>();

        //if card is placed in foundation, it must stack Ace to King
        if (c2.foundation) {
            if (c1.suit == c2.suit || (c1.value == 1 && c2.suit == null))
            {
                if (c1.value == c2.value + 1)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        //in the tableau pile, stack cards according to alternative colors from King to Ace
        else
        {
            if (c1.value == c2.value -1)
            {
                bool card1Red = true;
                bool card2Red = true;

                if (c1.suit == "C" || c1.suit == "S")
                {
                    card1Red = false;
                }
                if (c2.suit == "C" || c2.suit == "S")
                {
                    card2Red = false;
                }
                if (card1Red == card2Red)
                {
                   
                    print("Cannot stack");
                    return false;
                }
                else
                {
                    print("Can stack");
                    return true;
                }
            }   
        }
        return false;
    }

    // if card 1 is stackable on card 2
    // cards should stack in the same position and sort downwards
    public void Stack(GameObject selected)
    {
        Interactable c1 = card1.GetComponent<Interactable>();
        Interactable c2 = selected.GetComponent<Interactable>();
        float yOffset = 3.0f;
        
        if (c2.foundation || (!c2.foundation && c2.value == 13))
        {
            yOffset = 0;
        }
        card1.transform.position = new Vector3(selected.transform.position.x, selected.transform.position.y - yOffset,
            selected.transform.position.z);
        card1.transform.parent = selected.transform;

        //user can move cards from the top foundation slots
        if (c1.foundation && c2.foundation && c1.value == 1)
        {
            cardManager.foundationPos[c1.row].GetComponent<Interactable>().value = 0;
            cardManager.foundationPos[c1.row].GetComponent<Interactable>().suit = null;
        }
        else if (c1.foundation)
        {
            //record the value of the foundation card slot when a card is removed
            cardManager.foundationPos[c1.row].GetComponent<Interactable>().value = c1.value - 1;

        }
        else
        {
            //if a card is moved from a tableau column, remove it 
            cardManager.tableau[c1.row].Remove(c1.name);
        }

        c1.row = c2.row;
        //if a card is moved to the foundation slot, assign it's value and suit to the foundation slot
        if (c2.foundation)
        {
            cardManager.foundationPos[c1.row].GetComponent<Interactable>().value = c1.value;
            cardManager.foundationPos[c1.row].GetComponent<Interactable>().suit = c1.suit;
            c1.foundation = true;
        }
        else
        {
            c1.foundation = false;
        }
        card1 = this.gameObject;
    }
    
    
}
