using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInstructionswithButton : MonoBehaviour
{
    public AudioSource Instructions;

    private bool isPlay;

    public void PlayInstructions()
    {
        //Instructions.loop = false;
        //Instructions.Play();

        if(isPlay == false)
        {
            Instructions.Play();
            isPlay = true;
        }

        DelayActivateInstructions(Instructions.clip.length);


    }

    IEnumerator DelayActivateInstructions(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        
            isPlay = false;
        


    }
}
