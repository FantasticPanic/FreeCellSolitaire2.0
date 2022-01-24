using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSprite : MonoBehaviour
{

    public Sprite cardFace;

    //won't need this all cards are face up on start
    //public Sprite cardBase;

    private Image spriteRenderer;
    private Interactable interactable;
    private CardManager cardManager;



    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = CardManager.GenerateDeck();
        cardManager = FindObjectOfType<CardManager>();

        int i = 0;
        //get each of the card sprites, attach cardface image
        foreach (string card in deck)
        {
            if (this.name == card)
            {
                cardFace = cardManager.cardFaces[i];
            }
            i++;
        }
        spriteRenderer = GetComponent<Image>();
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = cardFace;
    }
}
