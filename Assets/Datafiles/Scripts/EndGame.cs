using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public StopWatch StopWatchScript;
    public GameObject Camera;
    public AudioSource EndOfTheGame;

    // Start is called before the first frame update
    void Start()
    {
        StopWatchScript = Camera.GetComponent<StopWatch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<CubeCollision>().isEntered && StopWatchScript.timerActive)
        {
            StopWatchScript.timerActive = false;
            EndOfTheGame.Play();
        }
    }
}
