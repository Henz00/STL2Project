using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 10;

    float xAxis;
    float yAxis;

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xAxis * movementSpeed, yAxis * movementSpeed, 0);
        movement *= Time.deltaTime*10;
        transform.Translate(movement);
    }
}
