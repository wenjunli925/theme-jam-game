using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public AudioSource LosetheGame;

    public float totalAmount;
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = totalAmount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = totalAmount.ToString();

        if(totalAmount < 0 && gameObject.GetComponent<StopWatch>().timerActive)
        {
            gameObject.GetComponent<StopWatch>().timerActive = false;
            LosetheGame.Play();
        }
    }
}
