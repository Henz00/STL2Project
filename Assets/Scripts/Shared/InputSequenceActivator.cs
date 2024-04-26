using UnityEngine;

public class InputSequenceActivator : MonoBehaviour
{
    public string[] inputSequence;
    private int currentIndex = 0; 

    public GameObject objectToActivate;
    AudioSource onCorrectInput;

    private void Awake()
    {
        onCorrectInput = GameObject.Find("OnCorrectInput").GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.anyKeyDown)
        {
 
            if (Input.GetKeyDown(inputSequence[currentIndex]))
            {

                currentIndex++;
                onCorrectInput.Play();

                char input = 'c';
                if (input.GetType() == typeof(string))
                {

                }

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