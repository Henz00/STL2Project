using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairEscape : MonoBehaviour
{
    private bool insideCollider;

    void Awake()
    {
        insideCollider = false;
    }

    void Update()
    {
        if (insideCollider)
            if (Input.GetKeyDown(KeyCode.E))
                SceneManager.LoadScene("MainMenu");
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
