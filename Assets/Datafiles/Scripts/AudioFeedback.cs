using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFeedback : MonoBehaviour
{
    public AudioSource YSound;
    public AudioSource NSound;
    public AudioSource Nope;
    public bool isUnlocked;

    // Start is called before the first frame update
    void Start()
    {
        isUnlocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && !isUnlocked)
        {
            YSound.Play();

            StartCoroutine(DelayEnableMovement(5));

        }

        if (Input.GetKeyDown(KeyCode.N) && !isUnlocked)
        {
            NSound.Play();
            isUnlocked = true;
            
        }

       
    }

    public void PlayNopeSound()
    {
        Nope.Play();
    }

    IEnumerator DelayEnableMovement(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        NSound.Play();
        isUnlocked = true;
    }



}
