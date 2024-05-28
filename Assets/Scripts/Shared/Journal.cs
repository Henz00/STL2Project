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
    readonly string[] journal_data =
    {
        "Coding/programming\n\nIn coding, programs generally reads from the top to the bottom. Therefore, try to think about the program in steps",
        "Console\n\n The console is a helpful tool to make your program tell you something. You'll see multiple times that we're \"writing\" in the console, which just means that were asking the program to print something out for us",
        "Comments\n\nIt's possible to write comments in your code by typing in \"//\", followed by whatever necessary comment in text. Used to help with documentation, note-taking, etc.",
        "Data types\n\nIn coding, like with anything, saving stuff is good. Here we save stuff by telling the computer what type of stuff we're saving, e.g. a number (called a float), a whole number only (called an int), text (called a string), true or false (called a bool), etc.",
        "IF statement\n\nUse the if statement to specify a block of C# code to be executed if a condition is True. The condition is written inside the normal parantheses brackets, and the stuff you want to run is written inside the curly brackets",
        "Methods\n\nMethods are essentially tasks you can ask the program to do, and it's usually written after picking an object (writing the name) and then typing in a \".\" dot. For instance, you can use the \".Length\" method to find out how long a string is.",
        "Type casting\n\nA more advanced technique, used to make one type of data (remember data types) into another data type. For instance, you can cast a float type to an int type by writing \"(int)\" in front of the float"

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
