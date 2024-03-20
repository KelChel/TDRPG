using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
   
    private bool gameEnded = false;
    public int current_money;
    public Upgrade upgradehero;
    public TextMeshProUGUI moneycheck;
    

    void Start()
    {
        current_money = PlayerPrefs.GetInt("Current_money" , current_money);
        moneycheck.text = current_money.ToString();
    }
    void Update()
    {
        if (gameEnded)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");
        Time.timeScale = 0;
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
