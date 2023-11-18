using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }

    public void PurchaseFirstTurret()
    {
        buildManager.SetTurretToBuild(buildManager.firstTurretPrefab);
    }

    public void PurchaseSecondTurret()
    {
        buildManager.SetTurretToBuild(buildManager.secondTurretPrefab);
    }

    public void PurchaseThirdTurret()
    {
        buildManager.SetTurretToBuild(buildManager.thirdTurretPrefab);
    }

    public void PurchaseFourthTurret()
    {
        buildManager.SetTurretToBuild(buildManager.fourthTurretPrefab);
    }
}
