using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;

    }

    public GameObject firstTurretPrefab;

    public GameObject secondTurretPrefab;

    public GameObject thirdTurretPrefab;

    public GameObject fourthTurretPrefab;



    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    public void ResetTurretToBuild()
    {
        turretToBuild = null;
    }
}
