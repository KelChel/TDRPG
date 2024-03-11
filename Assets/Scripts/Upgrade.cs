using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{

    void Start()
    {
        if (PlayerPrefs.GetInt("Turret1Damage") == 0)
        {
            PlayerPrefs.SetInt("Turret1Damage", 50);
        }
    }

    public void heroUpgrade()
    {
        
      
        int count = PlayerPrefs.GetInt("Turret1Damage");
        PlayerPrefs.SetInt("Turret1Damage", count + 1);
        Debug.Log(count + 1);
    }

}
