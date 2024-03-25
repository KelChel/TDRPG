using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buy : MonoBehaviour
{

    public int current_money = 200;
    public Upgrade upgradehero;
    public TextMeshProUGUI moneycheck;
    
    public void Start()
    {
        current_money = PlayerPrefs.GetInt("Current_money", current_money);
        moneycheck.text = current_money.ToString();
    }
    public void BuyUpgrade()
    {
        if (current_money >= 10)
        {

            upgradehero.heroUpgrade();
            current_money = current_money - 10;
            moneycheck.text = current_money.ToString();
            PlayerPrefs.SetInt("Current_money", current_money);
            PlayerPrefs.Save();
            Debug.Log(current_money);
            
        }
        else
        {
            Debug.Log("Недосаточно денег");
        }
    }
}