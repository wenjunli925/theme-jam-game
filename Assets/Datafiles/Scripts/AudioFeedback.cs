using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioFeedback : MonoBehaviour
{
    public AudioSource YesSound;
    public AudioSource NoSound;

    public AudioSource FiveSecs;
    public AudioSource Nope;

    public AudioSource Instruction;

    public AudioSource Wall;

    public AudioSource Up;
    public AudioSource Down;
    public AudioSource Left;
    public AudioSource Right;
    public AudioSource LastYear;
    public AudioSource NextYear;
    

    public bool isUnlocked;
    public bool wall;

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
            FiveSecs.PlayDelayed(YesSound.clip.length);

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

    void HittheWall()
    {
        if (isUnlocked & wall)
        {
            Wall.Play();
            wall = false;
            
        }
        
    }

    void MoveLeft()
    {
        if (isUnlocked & !wall)
        {
            Left.Play();
        }
    }

    void MoveRight()
    {
        if (isUnlocked & !wall)
        {
            Right.Play();
        }
    }

    void MoveUp()
    {
        if (isUnlocked & !wall)
        {
            Up.Play();
        }
    }

    void MoveDown()
    {
        if (isUnlocked & !wall)
        {
            Down.Play();
        }
    }

    void MovetoLastYear()
    {
        if (isUnlocked & !wall)
        {
            LastYear.Play();
        }
    }

    void MovetoNextYear()
    {
        if (isUnlocked & !wall)
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
        isUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (wall)
        {
            HittheWall();
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

        NoSound.Play();
        isUnlocked = true;
    }



}
