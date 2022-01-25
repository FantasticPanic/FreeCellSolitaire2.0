using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    public bool foundation = false;
    public bool isMouseDragged;
    public bool stackable;

    public string suit;
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
        }
    }

    // Update is called once per frame
   
    void Update()
    {
        if (isMouseDragged)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        }
        

       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        isMouseDragged = true;
        //stackable = false;
        SelectedCard(this.gameObject);
        transform.parent.SetAsLastSibling();
        oldCardPosition = this.gameObject.transform.position;
        
        //idk what this is doing
        //userInput.Card(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {     
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
