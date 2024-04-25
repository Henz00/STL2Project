using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool canActivate = true;

    public bool CanInteract()
    {
        return canActivate;
    }

    public void Interact()
    {
        Debug.Log("Object activated!");
        gameObject.SetActive(true);
    }
}