using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public AudioSource Week;

    private void Start()
    {
        Week = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {   
            Debug.Log("Player arrived!");
            
            Week.Play();
        }
    }
}
