using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public KeyCode useKey = KeyCode.Space;

    private GameObject objectToActivate;

    private void Update()
    {
        if (Input.GetKeyDown(useKey))
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ObjectToUse"))
        {
            objectToActivate = other.GetComponent<ObjectToActivate>().targetObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ObjectToUse"))
        {
            objectToActivate = null;
        }
    }
}