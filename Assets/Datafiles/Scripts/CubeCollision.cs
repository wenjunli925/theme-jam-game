using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public AudioSource Week;
    public bool isEntered = false;

    private GameObject Clock;

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

            Week.Play();
        }

        if (gameObject.name == "A21_W32")
        {
            Clock.GetComponent<StopWatch>().timerActive = true;
        }
    }
}
