using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool canActivate = true;

    public bool CanInteract()
    {
        // Add any conditions for interaction here (e.g., player has a key)
        return canActivate;
    }

    public void Interact()
    {
        Debug.Log("Object activated!");
        gameObject.SetActive(true);
    }
}