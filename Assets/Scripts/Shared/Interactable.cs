using UnityEngine;

public class Interactable : MonoBehaviour
{
    public KeyCode useKey = KeyCode.E;
    public GameObject objectToActivate;

    void Update()
    {
        if (Input.GetKeyDown(useKey))
        {
            ActivateObject();
        }
    }
    void ActivateObject()
    {
        if (objectToActivate != null && objectToActivate.activeSelf)
        {
            objectToActivate.SetActive(true);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        }
    }
}