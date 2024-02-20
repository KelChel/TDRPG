using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public GameObject node;
    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.Instance;
    }

    private void OnMouseEnter()
    {
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }


    private void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("нельзя");
            return;
        }
        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();

        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
        // Затем ресетнуть турель для постройки и поменять кнопку на скилл.
        node.SetActive(false);
    }
}
