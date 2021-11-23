using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferTasks : MonoBehaviour
{
    public GameObject Task;
    //public GameObject Instruction;

    public Transform NewParent;
    public GameObject TransferTarget;

    public Material Normal;
    public Material Block;

    MeshRenderer my_renderer;

    // Start is called before the first frame update
    void Start()
    {
 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Transfer()
    {
        Task.transform.SetParent(NewParent);
        //Instruction.transform.SetParent(NewParent);

        gameObject.GetComponent<MeshRenderer>().material = Normal;
        TransferTarget.GetComponent<MeshRenderer>().material = Block;
    }
}
