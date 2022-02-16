﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class CardManager : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public GameObject canvas;
    public GameObject[] tableauPos;
    public GameObject[] foundationPos;
    public GameObject winText;
    public TextMeshProUGUI finishTime;


    public static string[] suits = { "C", "D", "S", "H" };
    public static string[] values = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    public List<string>[] tableau;
    public List<string>[] foundation;

    List<string> tabPos0 = new List<string>();
    List<string> tabPos1 = new List<string>();
    List<string> tabPos2 = new List<string>();
    List<string> tabPos3 = new List<string>();
    List<string> tabPos4 = new List<string>();
    List<string> tabPos5 = new List<string>();
    List<string> tabPos6 = new List<string>();
    List<string> tabPos7 = new List<string>();
    List<string> tabPos8 = new List<string>();


    public static List<string> deck;


    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
                newDeck.Add(s + v);
            }
        }
        return newDeck;
    }

    public void PlayCards()
    {
        deck = GenerateDeck();
        Shuffle(deck);
        CardSort();
        SolitaireDeal();


        foreach (string card in deck)
        {
            //print any leftover cards in the console
            print(card);
        }
    }

    //Used to take in the deck list and shuffles it 
    public static void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    void SolitaireDeal()
    {
        //place a card int   
        for (int i = 0; i < 8; i++)
        {

            float yOffset = 5.0f;
            float xOffset = 5.0f;

            foreach (string card in tableau[i])
            {
                GameObject newCard = Instantiate(cardPrefab, new Vector3(tableauPos[i].transform.position.x + xOffset, tableauPos[i].transform.position.y - yOffset,
                    1), Quaternion.identity, tableauPos[i].transform);
                newCard.name = card;
                newCard.GetComponent<Interactable>().row = i;
                newCard.transform.SetParent(tableauPos[i].transform);
                newCard.GetComponent<Interactable>().isBlocked = true;
                yOffset = yOffset + 50.0f;
                xOffset = xOffset + 10.0f;

            }
        }

    }

    //sort cards into 8 rows
    void CardSort()
    {
        //in first 4 columns, draw 7 cards
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {

                tableau[i].Add(deck.Last<string>());
                deck.RemoveAt(deck.Count - 1);

            }
        }
        //in last 4 columns, draw 6 cards
        for (int i = 4; i < 8; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                tableau[i].Add(deck.Last<string>());
                deck.RemoveAt(deck.Count - 1);

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tableau = new List<string>[] { tabPos0, tabPos1, tabPos2, tabPos3, tabPos4, tabPos5, tabPos6, tabPos7, tabPos8 };
        PlayCards();
        TimerController.instance.BeginTimer();
        winText.SetActive(false);
    }

    void CardColliders()
    {
        //get the lowest card and turn on 
        for (int i = 0; i < 8; i++)
        {
            tableauPos[i].transform.GetChild(tableauPos[i].transform.childCount - 1).transform.GetComponent<Interactable>().isBlocked = false;
        }
    }

    void WinCondition()
    {
        for (int i = 0; i < foundationPos.Length; i++)
        {
            if (foundationPos[i].transform.childCount >= 14)
            {
                WinGame();
            }
        }
    }

    public void WinGame()
    {
            winText.SetActive(true);
            winText.transform.SetAsLastSibling();
            TimerController.instance.EndTimer();
            finishTime.text = "Finish Time: " + TimerController.instance.currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        CardColliders();
        if (Input.GetKeyDown(KeyCode.W))
        {
            WinGame();
        }
        WinCondition();
     }
}

