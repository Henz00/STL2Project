using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Journal : MonoBehaviour
{
    GameObject journal;
    GameObject leftPage;
    GameObject rightPage;
    bool isKeyDown = false;
    int start;
    string[] journal_data =
    {
        "Data types",
        "IF statement\n\nUse the if statement to specify a block of C# code to be executed if a condition is True.",
        "Console\n\n The console is a helpful tool to make your program tell you something",


    };
    void Awake()
    {
        journal = GameObject.Find("Journal");
        leftPage = GameObject.Find("LeftPage");
        rightPage = GameObject.Find("RightPage");
    }
    void Start()
    {
        journal.SetActive(false);
        Debug.Log(journal_data[0]);
        Debug.Log(journal_data[1]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isKeyDown)
        {
            isKeyDown = true;
            if (!journal.activeSelf)
            {
                journal.SetActive(true);
                leftPage.GetComponent<TMP_Text>().text = journal_data[0];
                rightPage.GetComponent<TMP_Text>().text = journal_data[1];
                start = 2;
            }
            else
                journal.SetActive(false);

        }

        if (Input.GetKeyUp(KeyCode.Tab))
            isKeyDown = false;

        if(journal.activeSelf && Input.GetKeyDown(KeyCode.L) && start <= journal_data.Length - 1)
        {
            leftPage.GetComponent<TMP_Text>().text = "";
            if (start <= journal_data.Length - 1)
            {
                leftPage.GetComponent<TMP_Text>().text = journal_data[start];
                start++;
            }
            rightPage.GetComponent<TMP_Text>().text = "";

            if (start <= journal_data.Length - 1)
            {
                rightPage.GetComponent<TMP_Text>().text = journal_data[start];
                start++;
            }
        }

        //if(journal.activeSelf && Input.GetKeyDown(KeyCode.J) && start > 1)
        //{
        //    if(start > 1)
        //    {
        //        start--;
        //        rightPage.GetComponent<TMP_Text>().text = journal_data[start];
        //    }

        //    if(start > 0)
        //    {
        //        start--;
        //        leftPage.GetComponent<TMP_Text>().text = journal_data[start];
        //    }
        //}

    }
}
