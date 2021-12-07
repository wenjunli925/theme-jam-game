using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioFeedbackStart : MonoBehaviour
{
    public AudioSource YesSound;
    public AudioSource NoSound;

    public AudioSource Instruction;
    public AudioSource Location;

    public AudioSource Up;
    public AudioSource Down;
    public AudioSource Left;
    public AudioSource Right;
    public AudioSource LastYear;
    public AudioSource NextYear;


    InputActions actions;

    private void Awake()
    {
        actions = new InputActions();

        actions.Player.Yes.performed += ctx => YPressed();
        actions.Player.No.performed += ctx => NPressed();

        actions.Player.Insturction.performed += ctx => SayInstruction();
        actions.Player.Locate.performed += ctx => TellLocation();


        actions.Player.Up.performed += ctx => MoveUp();
        actions.Player.Down.performed += ctx => MoveDown();
        actions.Player.Left.performed += ctx => MoveLeft();
        actions.Player.Right.performed += ctx => MoveRight();
        actions.Player.LastYear.performed += ctx => MovetoLastYear();
        actions.Player.NextYear.performed += ctx => MovetoNextYear();


    }

    void YPressed()
    {
        YesSound.Play();
    }

    void NPressed()
    {
        NoSound.Play();
    }

    void TellLocation()
    {
        Location.Play();
    }

    void SayInstruction()
    {
        Instruction.Play();
    }




    void MoveLeft()
    {

        Left.Play();

    }

    void MoveRight()
    {
        Right.Play();
    }

    void MoveUp()
    {
        Up.Play();
    }

    void MoveDown()
    {
        Down.Play();
    }

    void MovetoLastYear()
    {
        LastYear.Play();
    }

    void MovetoNextYear()
    {
        NextYear.Play();
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

    }

    // Update is called once per frame
    void Update()
    {



    }
}
  
