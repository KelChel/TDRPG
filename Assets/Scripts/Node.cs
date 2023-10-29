using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;

    private GameObject turret;

    public BuildManager buildManager;

    public Renderer rend;
    public Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }


    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Турель не выбрана");
            return;
        }
        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();

        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);

    }
}
