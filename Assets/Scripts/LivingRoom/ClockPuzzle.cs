using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockPuzzle : MonoBehaviour
{
    GameObject inputField;
    GameObject player;
    GameObject clock;
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
        clock = GameObject.Find("ClockClue");
        answer = "(int)";
    }

    void Start()
    {
        clock.SetActive(false);
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
                puzzleText.text = "double x = 5.8;\r\nint y = 6;\r\n\r\nConsole.WriteLine(_____x+y + \\\" inputs long\\\");";
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
            puzzleText.text = "double x = 5.8;\r\nint y = 6;\r\n\r\nConsole.WriteLine((int)x+y + \\\" inputs long\\\");";
            clock.SetActive(true);
            clock.GetComponent<TMP_Text>().text = "Open";
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
