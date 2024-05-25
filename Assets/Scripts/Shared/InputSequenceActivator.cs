using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputSequenceActivator : MonoBehaviour
{
    public string[] inputSequence;
    private int currentIndex = 0;
    public List<AudioClip> clips = new List<AudioClip>();

    public GameObject objectToActivate;
    private GameObject escapeDoor;
    AudioSource onCorrectInput;
    AudioSource onWrongInput;

    private void Awake()
    {
        onCorrectInput = GameObject.Find("OnCorrectInput").GetComponent<AudioSource>();
        onWrongInput = GameObject.Find("OnWrongInput").GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().name == "LivingRoom")
        {
            escapeDoor = GameObject.Find("OpenDoor");
            escapeDoor.SetActive(false);
        }
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
                    if (SceneManager.GetActiveScene().name == "LivingRoom")
                        escapeDoor.SetActive(true);

                    if (objectToActivate != null)
                    {
                        objectToActivate.SetActive(true);
                    }
                }
            }
            else if(currentIndex > 0)
            {
                currentIndex = 0;
                onWrongInput.Play();
            }
        }
    }
}