using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public int current_money;

    public void EndGainMoney(int money)
    {
        current_money = PlayerPrefs.GetInt("Current_money", current_money) + money;
        PlayerPrefs.SetInt("Current_money", current_money);
        Debug.Log(current_money);
    }
}
