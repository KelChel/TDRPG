using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject level;
    public GameObject settings;
    public GameObject bestiary;
    public GameObject authors;
    public GameObject hero;
    public List<GameObject> activePanel = new List<GameObject>();

    public void OpenMenu()
    {
        menu.SetActive(true);
        activePanel.Add(menu);
        Debug.Log("openMenu");
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
        activePanel.Add(settings);
    }

    public void OpenBestiary()
    {
        bestiary.SetActive(true);
        activePanel.Add(bestiary);
    }

    public void OpenAuthors()
    {
        authors.SetActive(true);
        activePanel.Add(authors);
    }
    
    public void OpenHero()
    {
        hero.SetActive(true);
        activePanel.Add(hero);
    }


    public void CloseMenu()
    {
        menu.SetActive(false);
        activePanel.Remove(menu);
        Debug.Log("openMenu");
    }

    public void CloseLevel()
    {
        level.SetActive(false);
        activePanel.Remove(level);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
        activePanel.Remove(settings);
    }

    public void CloseBestiary()
    {
        bestiary.SetActive(false);
        activePanel.Remove(bestiary);
    }

    public void CloseAuthors()
    {
        authors.SetActive(false);
        activePanel.Remove(authors);
    }

    public void CloseHero()
    {
        hero.SetActive(false);
        activePanel.Remove(hero);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        
            if (activePanel.Count > 0)
            {
                activePanel[activePanel.Count - 1].SetActive(false); 
            }
        }
    }
}
