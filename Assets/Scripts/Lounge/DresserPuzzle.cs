using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DresserPuzzle : MonoBehaviour
{
    GameObject InputField;

    void Awake()
    {
        InputField = GameObject.Find("PuzzleInput");
    }

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                InputField.SetActive(true);
                Debug.Log("It works");
            }
        }
    }
}
