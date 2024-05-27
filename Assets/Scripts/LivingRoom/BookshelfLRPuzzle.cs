using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookshelfLRPuzzle : MonoBehaviour
{
    GameObject inputField;
    GameObject player;
    GameObject livingRoomBookshelf;
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
        livingRoomBookshelf = GameObject.Find("LivingRoomBookshelfClue");
        answer = "int";
    }
    void Start()
    {
        livingRoomBookshelf.SetActive(false);
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
            puzzleText.text = "int x = 11;\r\n\r\nConsole.WriteLine(\"Remember this number: \" + x);";
            livingRoomBookshelf.SetActive(true);
            livingRoomBookshelf.GetComponent<TMP_Text>().text = "Use this clue as the sound of progress";
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
