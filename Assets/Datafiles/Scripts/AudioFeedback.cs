using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioFeedback : MonoBehaviour
{
    public AudioSource YSound;
    public AudioSource NSound;
    public AudioSource Nope;
    public bool isUnlocked;

    InputActions actions;

    private void Awake()
    {
        actions = new InputActions();

        actions.Player.Yes.performed += ctx => YPressed();
        actions.Player.No.performed += ctx => NPressed();

    }

    void YPressed()
    {
        if (!isUnlocked)
        {
            YSound.Play();

            StartCoroutine(DelayEnableMovement(5));

        }

    }

    void NPressed()
    {
        if (!isUnlocked)
        {
            NSound.Play();
            isUnlocked = true;

        }
    }



    private void OnEnable()
    {
        actions.Player.Enable();
    }

    private void OnDisable()
    {
        actions.Player.Disable();
    }



    // Start is called before the first frame update
    void Start()
    {
        isUnlocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Y) && !isUnlocked)
        //{
        //    YSound.Play();

        //    StartCoroutine(DelayEnableMovement(5));

        //}

        //if (Input.GetKeyDown(KeyCode.N) && !isUnlocked)
        //{
        //    NSound.Play();
        //    isUnlocked = true;

        //}


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
