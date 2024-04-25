using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
    
    TMP_InputField input;
    string answer;

    void Awake()
    {
        input = GameObject.Find("PuzzleInput").GetComponent<TMP_InputField>();
        input.onEndEdit.AddListener(OnInputEnter);
        answer = "case";
    }

    public void OnInputEnter(string text)
    {
        if(text.ToLower() == answer)
        {
            Debug.Log("It works");
        }
    }
}
