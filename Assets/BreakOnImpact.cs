using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnImpact : MonoBehaviour
{

    GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject == player)
        {
            Destroy(this.gameObject);
        }
    }

}
