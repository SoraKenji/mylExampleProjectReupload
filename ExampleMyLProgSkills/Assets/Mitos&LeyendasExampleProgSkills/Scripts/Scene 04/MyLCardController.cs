using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyLCardController : MonoBehaviour {
    Text txtDamage;
    Text txtGoldCost;
    Image imgCard;
    Text txtCardName;
    
    public void setCardComponents()
    {
        imgCard = transform.GetComponent<Image>();
        txtDamage = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        txtGoldCost = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        txtCardName = transform.GetChild(2).GetChild(0).GetComponent<Text>();
    }

    public void SetProperties(MyLCard card)
    {
        txtDamage.text = card.attack.ToString();
        txtGoldCost.text = card.goldCost.ToString();
        imgCard.sprite = card.art;
        txtCardName.text = card.mylCardName;
    }
}
