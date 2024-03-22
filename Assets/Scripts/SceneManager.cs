using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    // ����� ��� �������� ����� �� � ������
    public void LoadSceneByIndex(int sceneIndex)
    {
        // ���������, ���������� �� ����� � ��������� �������� � ������ ���� � ���������� ������
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // ��������� ����� �� � �������
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogWarning("Scene with index " + sceneIndex + " doesn't exist in the build settings.");
        }
    }
}