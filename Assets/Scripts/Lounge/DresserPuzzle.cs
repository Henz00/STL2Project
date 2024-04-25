using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DresserPuzzle : MonoBehaviour
{
    GameObject inputField;
    GameObject player;
    PauseMenu PauseMenu;
    private bool insideCollider;

    void Awake()
    {
        inputField = GameObject.Find("PuzzleInput");
        player = GameObject.Find("Player");
        PauseMenu = GameObject.Find("GameManager").GetComponent<PauseMenu>();
    }

    void Update()
    {
        if(insideCollider)
        {
            if (Input.GetKeyDown(KeyCode.E) && !inputField.activeSelf)
            {
                player.GetComponent<PlayerMovement>().enabled = false;
                PauseMenu.openUI = true;
                inputField.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && inputField.activeSelf)
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                PauseMenu.openUI = false;
                inputField.SetActive(false);
            }
        }
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