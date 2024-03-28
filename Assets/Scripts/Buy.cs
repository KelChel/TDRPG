using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buy : MonoBehaviour
{

    public int current_money;
    public Upgrade upgradehero;
    public TextMeshProUGUI moneycheck;
    
    public void Start()
    {
        
        
            PlayerPrefs.SetInt("Current_money", current_money);
            moneycheck.text = current_money.ToString();
    }
    public void BuyDamageUpgrade(string turretName)
    {
        if (current_money >= 10)
        {

            upgradehero.DamageUpgrade(turretName, 5);
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

    public void BuyRangeUpgrade(string turretName)
    {
        if (current_money >= 20)
        {

            upgradehero.RangeUpgrade(turretName);
            current_money = current_money - 20;
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

    public void BuyFireRateUpgrade(string turretName)
    {
        if (current_money >= 30)
        {

            upgradehero.FireRateUpgrade(turretName);
            current_money = current_money - 20;
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