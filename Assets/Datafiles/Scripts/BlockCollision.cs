using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class BlockCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Counter CounterScript;
    public AudioFeedback feedback;
    public TransferTasks transfer;

    public GameObject TransferTarget;

 
    public AudioSource Week;
    public AudioSource Day;

    public AudioSource Task;
    //public AudioSource Instruction;

    public Material Done;

    public bool isEntered = false;
    public bool isDone = false;

    public bool isMonday = false;

    public bool taskPushable = false;

    InputActions actions;

    private void Awake()
    {
        actions = new InputActions();

        actions.Player.Yes.performed += ctx => YPressed();
        actions.Player.No.performed += ctx => NPressed();

        actions.Player.Locate.performed += ctx => TellLocation();
    }

    void YPressed()
    {
        if (isEntered && !isDone)
        {
            movement.enabled = false;

            StartCoroutine(DelayEnableMovement(5));

            isEntered = true;


            if (taskPushable)
            {
                TransferTarget.GetComponent<BlockCollision>().enabled = false;
                TransferTarget.GetComponent<CubeCollision>().enabled = true;
            }

        }

    }

    void NPressed()
    {
        if (isEntered && !isDone)
        {
            if (taskPushable)
            {
                movement.enabled = true;
                //feedback.isUnlocked = true;

                CounterScript.totalAmount -= 1;

                isEntered = true;


                transfer.Transfer();
                TransferTarget.GetComponent<BlockCollision>().enabled = true;
                TransferTarget.GetComponent<CubeCollision>().enabled = false;

                gameObject.GetComponent<BlockCollision>().enabled = false;
                gameObject.GetComponent<CubeCollision>().enabled = true;
            }
            else
            {
                movement.enabled = false;
                feedback.isUnlocked = false;
                feedback.PlayNopeSound();

                isEntered = true;

            }

        }

    }

    void TellLocation()
    {
        if (isEntered)
        {
            Week.Play();
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


    private void OnTriggerEnter(Collider other)
    {
        if (!enabled) return;

        if (other.tag == "Player")
        {
            Debug.Log("Player arrived!");
            isEntered = true;

            if (!isDone)
            {
                movement.enabled = false;
                feedback.isUnlocked = false;

                PlaySound();
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!enabled) return;

        if (other.tag == "Player")
        {

            Debug.Log("Player left!");

            isEntered = false;

        }
    }

    private void PlaySound()
    {
        StartCoroutine(DelayPlaySound(1));
    }


    IEnumerator DelayEnableMovement(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        isDone = true;

        movement.enabled = true;
        //feedback.isUnlocked = true;

        gameObject.GetComponent<MeshRenderer>().material = Done;

        gameObject.GetComponent<CubeCollision>().enabled = true;
    }

    IEnumerator DelayPlaySound(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        if (isMonday)
        {
            Day.PlayDelayed(Week.clip.length);
            Task.PlayDelayed(Week.clip.length + Day.clip.length);
            //Instruction.PlayDelayed(Week.clip.length + Day.clip.length + Task.clip.length);
        }
        else
        {
            Day.Play();
            Task.PlayDelayed(Day.clip.length);
            //Instruction.PlayDelayed(Day.clip.length + Task.clip.length);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Y) && isEntered && !isDone)
        //{
        //    movement.enabled = false;

        //    StartCoroutine(DelayEnableMovement(5));



        //    isEntered = true;



        //    if (taskPushable)
        //    {
        //        TransferTarget.GetComponent<BlockCollision>().enabled = false;
        //        TransferTarget.GetComponent<CubeCollision>().enabled = true;
        //    }


        //}

        //if (Input.GetKeyDown(KeyCode.N) && isEntered && !isDone)
        //{
        //    if (taskPushable)
        //    {
        //        movement.enabled = true;
        //        //feedback.isUnlocked = true;

        //        CounterScript.totalAmount -= 1;

        //        isEntered = true;


        //        transfer.Transfer();
        //        TransferTarget.GetComponent<BlockCollision>().enabled = true;
        //        TransferTarget.GetComponent<CubeCollision>().enabled = false;

        //        gameObject.GetComponent<BlockCollision>().enabled = false;
        //        gameObject.GetComponent<CubeCollision>().enabled = true;
        //    }
        //    else
        //    {
        //        movement.enabled = false;
        //        feedback.isUnlocked = false;
        //        feedback.PlayNopeSound();

        //        isEntered = true;

        //    }

        //}
    }
}
