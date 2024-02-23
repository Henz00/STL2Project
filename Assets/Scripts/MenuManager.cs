using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    GameObject FrontMenu;
    GameObject SceneSelectionMenu;

    void Awake()
    {
        FrontMenu = GameObject.Find("FrontMenu");
        SceneSelectionMenu = GameObject.Find("SceneSelectionMenu");
    }

    void Start()
    {
        SceneSelectionMenu.SetActive(false);
    }
    public void SceneSelection()
    {
        if(!FrontMenu.activeInHierarchy)
        {
            SceneSelectionMenu.SetActive(false);
            FrontMenu.SetActive(true);
        }
        else
        {
            SceneSelectionMenu.SetActive(true);
            FrontMenu.SetActive(false);
        }
    }
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
