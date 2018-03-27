using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScene04 : MonoBehaviour {
    public MyLCard[] listOfCards = new MyLCard[10];
    public Transform cardPrefab;
    public Transform parentCards, parentCards_2;

    MyLCardController[] _listOfCards = new MyLCardController[10];


    int current = 0;


    public void createCard()
    {
        if (10 > current)
        {
            if (5 > current)
            {
                _listOfCards[current] = Instantiate(cardPrefab, parentCards).GetComponent<MyLCardController>();
            }
            else
            {
                _listOfCards[current] = Instantiate(cardPrefab, parentCards_2).GetComponent<MyLCardController>();
            }
            _listOfCards[current].setCardComponents();
            _listOfCards[current].SetProperties(listOfCards[current]);
            current++;
        }
    }
}
