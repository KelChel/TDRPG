using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTurretFireRate : MonoBehaviour
{
    public void heroUpgradeFireRate()
    {
        if (PlayerPrefs.GetInt("Turret1FireRate") == 0)
        {
            PlayerPrefs.SetInt("Turret1FireRate", 1);
        }
        int count = PlayerPrefs.GetInt("Turret1FireRate");
        PlayerPrefs.SetInt("Turret1FireRate", count + 1);
        Debug.Log(count + 1);
    }
}
