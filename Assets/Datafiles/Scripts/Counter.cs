using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
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
    }
}
