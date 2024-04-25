using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public KeyCode useKey = KeyCode.Space; // Change this to the key you want to use

    private GameObject objectToActivate; // The object the player is standing next to

    private void Update()
    {
        // Check if the use key is pressed
        if (Input.GetKeyDown(useKey))
        {
            // Check if the player is standing next to an object to activate
            if (objectToActivate != null)
            {
                // Activate the object
                objectToActivate.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collided with an object to activate
        if (other.CompareTag("ObjectToActivate"))
        {
            objectToActivate = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Reset the object to activate when the player moves away from it
        if (other.CompareTag("ObjectToActivate"))
        {
            objectToActivate = null;
        }
    }
}