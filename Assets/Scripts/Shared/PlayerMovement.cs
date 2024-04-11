using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    //float xAxis;
    //float yAxis;

    // Update is called once per frame
    //void Update()
    //{
      //  xAxis = Input.GetAxisRaw("Horizontal");
      //  yAxis = Input.GetAxisRaw("Vertical");

      //  Vector3 movement = new Vector3(xAxis * movementSpeed, yAxis * movementSpeed, 0);
      //  movement *= Time.deltaTime*10;
      //  transform.Translate(movement);
    //}

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
