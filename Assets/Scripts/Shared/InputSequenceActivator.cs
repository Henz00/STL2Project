using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSequenceActivator : MonoBehaviour
{
    public string[] inputSequence;
    private int currentIndex = 0;
    public List<AudioClip> clips = new List<AudioClip>();

    public GameObject objectToActivate;
    AudioSource onCorrectInput;
    AudioSource onWrongInput;

    private void Awake()
    {
        onCorrectInput = GameObject.Find("OnCorrectInput").GetComponent<AudioSource>();
        onWrongInput = GameObject.Find("OnWrongInput").GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.anyKeyDown)
        {
 
            if (Input.GetKeyDown(inputSequence[currentIndex]))
            {

                currentIndex++;
                onCorrectInput.Play();

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
                onWrongInput.Play();
            }
        }
    }
}