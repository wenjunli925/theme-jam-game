using UnityEngine;
using System.Collections;

public class BlockCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Counter CounterScript;
    public GameObject Camera;

    public AudioSource Week;
    public AudioSource Task;
    public AudioSource Instruction;

    private bool isEntered = false;
    private bool isDone = false;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player arrived!");
            isEntered = true;

            if (!isDone)
            {
                movement.enabled = false;
                PlaySound();
            }
            
        }
    }

    private void PlaySound()
    {
            Week.Play();
            Task.PlayDelayed(Week.clip.length);
            Instruction.PlayDelayed(Week.clip.length + Task.clip.length);
    }

    void Start()
    {
        CounterScript = Camera.GetComponent<Counter>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && isEntered && !isDone)
        {
            movement.enabled = false;
            StartCoroutine(DelayEnableMovement(5));

            isEntered = false;
            isDone = true;
                       
        }

        if (Input.GetKeyDown(KeyCode.N) && isEntered && !isDone)
        {
            movement.enabled = true;
            CounterScript.totalAmount -= 1;

            isEntered = false;
        }
    }

    IEnumerator DelayEnableMovement(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        movement.enabled = true;
        gameObject.GetComponent<CubeCollision>().enabled = true;
    }
}
