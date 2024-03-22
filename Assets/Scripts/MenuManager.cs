using UnityEngine;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    public List<GameObject> canvasPanels; // ������ ���� ������� �������
    public GameObject currentPanel; // ������� ������

    // ����� ��� ����������� ��������� ������ � ������� �������
    public void ShowPanel(GameObject panelToShow)
    {
        // �������� ������� ������
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }

        // ���������, ���������� �� ��������� ������ � ������
        if (canvasPanels.Contains(panelToShow))
        {
            // ���������� ��������� ������ � ��������� �������
            panelToShow.SetActive(true);
            currentPanel = panelToShow;
        }
        else
        {
            Debug.LogError("Panel is not in the canvas panels list!");
        }
    }
}