using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class CubeCollision : MonoBehaviour
{
    public AudioSource Week;
    public AudioSource Day;

    public bool isEntered = false;

    public bool isMonday = false;

    private GameObject Clock;

    InputActions actions;

    private void Awake()
    {
        actions = new InputActions();

        
        actions.Player.Locate.performed += ctx => TellLocation();

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



    private void Start()
    {
        Clock = GameObject.Find("Main Camera");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!enabled) return;

        if (other.tag == "Player")
        { 

            Debug.Log("Player arrived!");

            isEntered = true;

            StartCoroutine(DelayPlaySound(1));
        }

        if (gameObject.name == "A21_W32_Mon")
        {
            Clock.GetComponent<StopWatch>().timerActive = true;
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

    IEnumerator DelayPlaySound(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        if (isMonday)
        {
            Week.Play();
            Day.PlayDelayed(Week.clip.length);
        }

        Day.Play();
    }

}


