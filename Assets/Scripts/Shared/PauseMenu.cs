using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameObject FrontMenu;
    GameObject ExitMenu;
    GameObject MenuButtonsHolder;
    GameObject InputField;

    void Awake()
    {
        FrontMenu = GameObject.Find("FrontMenu");
        ExitMenu = GameObject.Find("ExitMenu");
        MenuButtonsHolder = GameObject.Find("MenuButtonsHolder");
        InputField = GameObject.Find("PuzzleInput");
    }
    void Start()
    {
        MenuButtonsHolder.SetActive(false);
        InputField.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        if (!MenuButtonsHolder.activeSelf)
        {
            FrontMenu.SetActive(true);
            ExitMenu.SetActive(false);
            MenuButtonsHolder.SetActive(true);
        }
        else
        {
            FrontMenu.SetActive(false);
            MenuButtonsHolder.SetActive(false);
        }
    }

    public void OpenExitMenu()
    {
        if (FrontMenu.activeSelf)
        {
            ExitMenu.SetActive(true);
            FrontMenu.SetActive(false);
        }
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitToDesktop()
    {
        Debug.Log("Goodbye");
        Application.Quit();
    }
}
