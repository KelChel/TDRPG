using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
   
    private bool gameEnded = false;
   
    public TextMeshProUGUI moneycheck;
    

   
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

   

    }


