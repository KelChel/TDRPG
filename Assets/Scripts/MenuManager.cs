using UnityEngine;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    public List<GameObject> canvasPanels; // Список всех панелей канваса
    public GameObject currentPanel; // Текущая панель

    // Метод для отображения указанной панели и скрытия текущей
    public void ShowPanel(GameObject panelToShow)
    {
        // Скрываем текущую панель
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }

        // Проверяем, содержится ли указанная панель в списке
        if (canvasPanels.Contains(panelToShow))
        {
            // Отображаем указанную панель и обновляем текущую
            panelToShow.SetActive(true);
            currentPanel = panelToShow;
        }
        else
        {
            Debug.LogError("Panel is not in the canvas panels list!");
        }
    }
}