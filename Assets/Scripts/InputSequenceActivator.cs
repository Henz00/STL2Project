using UnityEngine;

public class InputSequenceActivator : MonoBehaviour
{
    public string[] inputSequence;
    private int currentIndex = 0; 

    public GameObject objectToActivate; 

    void Update()
    {

        if (Input.anyKeyDown)
        {
 
            if (Input.GetKeyDown(inputSequence[currentIndex]))
            {

                currentIndex++;


                if (currentIndex >= inputSequence.Length)
                {

                    currentIndex = 0;

                    if (objectToActivate != null)
                    {
                        objectToActivate.SetActive(true);
                    }
                }
            }
            else
            {
                currentIndex = 0;
            }
        }
    }
}
