using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public AudioSource Week;
    public bool isEntered = false;

    private void Start()
    {
        Week = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 

            Debug.Log("Player arrived!");

            isEntered = true;

            Week.Play();
        }
    }
}
