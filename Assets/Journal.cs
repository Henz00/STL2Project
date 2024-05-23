using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    string[] journal =
    {
        "Data types",
        "The if statement\n\nUse the if statement to specify a block of C# code to be executed if a condition is True."

    };
    void Start()
    {
        Debug.Log(journal[0]);
        Debug.Log(journal[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
