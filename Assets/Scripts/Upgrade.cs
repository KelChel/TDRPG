using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{


    public void DamageUpgrade(string turretName, int damage)
    {
        
        if (PlayerPrefs.GetInt(turretName) == 0)
        {
            PlayerPrefs.SetInt(turretName, 50);
        }

        int count = PlayerPrefs.GetInt(turretName);
        PlayerPrefs.SetInt(turretName, count + damage);
        Debug.Log(count + damage);
    }

    public void RangeUpgrade(string turretName)
    {

        if (PlayerPrefs.GetFloat(turretName) == 0f)
        {
            PlayerPrefs.SetFloat(turretName, 3f);
        }

        float count = PlayerPrefs.GetFloat(turretName);
        PlayerPrefs.SetFloat(turretName, count + 0.5f);
        Debug.Log(count + 0.5);
    }

}
