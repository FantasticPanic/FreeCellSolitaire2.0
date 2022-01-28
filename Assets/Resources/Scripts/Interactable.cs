using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    public bool onFoundation = false;
    public bool isMouseDragged;
    public bool stackable;
    public bool isBlocked;

    public string suit;
    public string color;
    public int value;
    public int row;

    private string valueString;

    private float startPosX;
    private float startPosY;

    public Vector3 oldCardPosition;
    public Vector3 newCardPosition;
    UserInput userInput;

  

    public enum CardState
    {
        tableau,
        freeCell,
        foundation,
        none,
    }

    public CardState cardState;

    // Start is called before the first frame update
    void Start()
    {
        oldCardPosition = transform.position;
        userInput = GameObject.Find("GameManager").GetComponent<UserInput>();
        if (CompareTag("Card"))
        {
            //suit will be first letter
            suit = transform.name[0].ToString();
            //value will be second letter
            for (int i = 1; i < transform.name.Length; i++)
            {
                char c = transform.name[i];
                valueString = valueString + c.ToString();
            }
            if (valueString == "A")
            {
                value = 1;
            }
            if (valueString == "2")
            {
                value = 2;
            }
            if (valueString == "3")
            {
                value = 3;
            }
            if (valueString == "4")
            {
                value = 4;
            }
            if (valueString == "5")
            {
                value = 5;
            }
            if (valueString == "6")
            {
                value = 6;
            }
            if (valueString == "7")
            {
                value = 7;
            }
            if (valueString == "8")
            {
                value = 8;
            }
            if (valueString == "9")
            {
                value = 9;
            }
            if (valueString == "10")
            {
                value = 10;
            }
            if (valueString == "J")
            {
                value = 11;
            }
            if (valueString == "Q")
            {
                value = 12;
            }
            if (valueString == "K")
            {
                value = 13;
            }

            if (suit == "S" || suit == "C")
            {
                color = "black";
            }
            else
            {
                color = "red";
            }
        }
    }

    // Update is called once per frame
   
    void Update()
    {
        if (isMouseDragged)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        }

        if (isBlocked)
        {
            transform.GetComponent<Collider>().enabled = false;
        }
        else
        {
            transform.GetComponent<Collider>().enabled = true;
        }
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        isMouseDragged = true;
        stackable = false;
        SelectedCard(this.gameObject);
        //moves the selected object out in the front of all other UI objects
        transform.parent.SetAsLastSibling();
        transform.parent.parent.SetAsLastSibling();
        oldCardPosition = this.gameObject.transform.position;
        
        //idk what this is doing
        userInput.card1 = this.gameObject;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       // userInput.Stack();
        isMouseDragged = false;
        userInput.card1 = null;
        userInput.card2 = null;

        if (stackable == false)
        {
            ResetCard();
        }
        
        print("Let Go!");


    }

    void OnTriggerStay(Collider other)
    {
        if (isMouseDragged)
        {
            if (other.gameObject.CompareTag("Card") || other.gameObject.CompareTag("FreeCell") || other.gameObject.CompareTag("Foundation"))
            {
                userInput.card2 = other.gameObject;
            }
        }

        // if statement stacks cards
        if (other.CompareTag("Card"))
        {
            Interactable c1 = this.GetComponent<Interactable>();
            Interactable c2 = other.GetComponent<Interactable>();
            this.stackable = true;
            float yOffset = 50.0f;
            float xOffset = 15.0f;

            if (this.isMouseDragged == false)
            {

                //if a card is on a tableau slot
                if (onFoundation == false && c1.value == (c2.value - 1) && c1.color != c2.color)
                {
                    c1.gameObject.transform.position = new Vector3(c2.transform.position.x + xOffset, c2.transform.position.y - yOffset,
                   1);
                    
                    c1.row = c2.row;
                    this.gameObject.transform.SetParent(c2.transform.parent);
                }

                //if a card is on a foundation slot
                else if (c2.onFoundation == true && c1.value == (c2.value + 1) && c1.suit == c2.suit)
                {
                    c1.gameObject.transform.position = new Vector3(c2.transform.position.x + xOffset, c2.transform.position.y - yOffset,
                 1);
                   
                    c1.row = c2.row;
                    this.gameObject.transform.SetParent(c2.transform.parent);
                    c2.isBlocked = true;
                }
            }
        }
    }
    

    void SelectedCard(GameObject selected)
    {
        print(selected.name + " selected");
        
    }


   public IEnumerator CardStatus(CardState cardState)
    {
        switch (cardState)
        {
            case CardState.tableau:
                {
                    print("card placed in tableau");
                    cardState = CardState.tableau;
                    break;
                }
            case CardState.freeCell:
                {
                    print("card placed in Free Cell");
                    cardState = CardState.freeCell;
                    break;
                }
            case CardState.foundation:
                {
                    print("card placed in Foundation");
                    cardState = CardState.foundation;
                    break;
                }
            case CardState.none:
                {
                    print("card returns to old position");
                    cardState = CardState.none;
                    break;
                }
        }
        yield return new WaitForSeconds(0.1f);
    }

    public void ResetCard()
    {
        this.gameObject.transform.position = oldCardPosition;
    }

}
