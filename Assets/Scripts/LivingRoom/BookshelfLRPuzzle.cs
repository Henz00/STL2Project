using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookshelfLRPuzzle : MonoBehaviour
{
    GameObject inputField;
    GameObject player;
    PauseMenu PauseMenu;
    private bool insideCollider;
    TMP_Text puzzleText;
    TMP_InputField input;
    string answer;

    void Awake()
    {
        inputField = GameObject.Find("PuzzleInput");
        player = GameObject.Find("Player");
        PauseMenu = GameObject.Find("GameManager").GetComponent<PauseMenu>();
        puzzleText = GameObject.Find("PuzzleText").GetComponent<TMP_Text>();
        insideCollider = false;
        input = GameObject.Find("PuzzleInput").GetComponent<TMP_InputField>();
        answer = "int";
    }

    void Update()
    {
        if (insideCollider)
        {
            if (Input.GetKeyDown(KeyCode.E) && !inputField.activeSelf)
            {
                input.onEndEdit.AddListener(OnInputEnter);
                player.GetComponent<PlayerMovement>().enabled = false;
                PauseMenu.openUI = true;
                inputField.SetActive(true);
                puzzleText.text = "___ x = 11;\r\n\r\nConsole.WriteLine(\"Remember this number: \" + x);";
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && inputField.activeSelf)
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                PauseMenu.openUI = false;
                inputField.SetActive(false);
                puzzleText.text = "";
                input.onEndEdit.RemoveAllListeners();
            }
        }
    }
    public void OnInputEnter(string text)
    {
        if (text.ToLower() == answer)
        {
            Debug.Log("Use this clue as the sound of progress");
            puzzleText.text = "int x = 11;\r\n\r\nConsole.WriteLine(\"Remember this number: \" + x);";
            //Implement final solution here
        }
        input.onEndEdit.RemoveAllListeners();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        insideCollider = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        insideCollider = false;
    }
}
