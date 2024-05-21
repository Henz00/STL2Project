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
}