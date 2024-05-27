using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookshelfPuzzle : MonoBehaviour
{
    GameObject inputField;
    GameObject player;
    GameObject loungeBookshelf;
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
        loungeBookshelf = GameObject.Find("LoungeBookshelfClue");
        answer = "//";
    }

    void Start()
    {
        loungeBookshelf.SetActive(false);
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
                puzzleText.text = "__ Comment this out to run the code\r\nif(!commented){\r\n\tConsole.WriteLine(\"next clue\");\r\n}";
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
            puzzleText.text = "// Comment this out to run the code\r\nif(!commented){\r\n\tConsole.WriteLine(\"next clue\");\r\n}";
            loungeBookshelf.SetActive(true);
            loungeBookshelf.GetComponent<TMP_Text>().text = "Listen to the sounds of the piano,\n the music guides the way";
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
