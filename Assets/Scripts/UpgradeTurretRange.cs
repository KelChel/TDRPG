using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTurretRange : MonoBehaviour
{
    public void heroUpgradeRange()
    {
        if (PlayerPrefs.GetInt("Turret1Range") == 0)
        {
            PlayerPrefs.SetInt("Turret1Range", 1);
        }
        int count = PlayerPrefs.GetInt("Turret1Range");
        PlayerPrefs.SetInt("Turret1Range", count + 1);
        Debug.Log(count + 1);
    }
}
