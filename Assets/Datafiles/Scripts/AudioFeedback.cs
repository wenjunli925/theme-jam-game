using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioFeedback : MonoBehaviour
{
    public AudioSource YesSound;
    public AudioSource NoSound;

    public AudioSource Nope;

    public AudioSource Instruction;

    public AudioSource Up;
    public AudioSource Down;
    public AudioSource Left;
    public AudioSource Right;
    public AudioSource LastYear;
    public AudioSource NextYear;
    

    public bool isUnlocked;

    InputActions actions;

    private void Awake()
    {
        actions = new InputActions();

        actions.Player.Yes.performed += ctx => YPressed();
        actions.Player.No.performed += ctx => NPressed();

        actions.Player.Insturction.performed += ctx => SayInstruction();


        actions.Player.Up.performed += ctx => MoveUp();
        actions.Player.Down.performed += ctx => MoveDown();
        actions.Player.Left.performed += ctx => MoveLeft();
        actions.Player.Right.performed += ctx => MoveRight();
        actions.Player.LastYear.performed += ctx => MovetoLastYear();
        actions.Player.NextYear.performed += ctx => MovetoNextYear();


    }

    void YPressed()
    {
        if (!isUnlocked)
        {
            YesSound.Play();

            StartCoroutine(DelayEnableMovement(5));

        }

    }

    void NPressed()
    {
        if (!isUnlocked)
        {
            NoSound.Play();
            isUnlocked = true;

        }
    }

    void SayInstruction()
    {
        Instruction.Play();
    }

    void MoveLeft()
    {
        if (isUnlocked)
        {
            Left.Play();
        }
    }

    void MoveRight()
    {
        if (isUnlocked)
        {
            Right.Play();
        }
    }

    void MoveUp()
    {
        if (isUnlocked)
        {
            Up.Play();
        }
    }

    void MoveDown()
    {
        if (isUnlocked)
        {
            Down.Play();
        }
    }

    void MovetoLastYear()
    {
        if (isUnlocked)
        {
            LastYear.Play();
        }
    }

    void MovetoNextYear()
    {
        if (isUnlocked)
        {
            NextYear.Play();
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

        NoSound.Play();
        isUnlocked = true;
    }



}
