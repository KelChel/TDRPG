using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    // Метод для загрузки сцены по её номеру
    public void LoadSceneByIndex(int sceneIndex)
    {
        // Проверяем, существует ли сцена с указанным индексом в списке сцен в настройках сборки
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Загружаем сцену по её индексу
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogWarning("Scene with index " + sceneIndex + " doesn't exist in the build settings.");
        }
    }
}