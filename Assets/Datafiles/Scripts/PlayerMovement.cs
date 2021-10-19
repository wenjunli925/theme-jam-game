using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.1f;

    //private float xDirection = 0.0f;
    //private float zDirection = 0.0f;

    // Update is called once per frame
    void Update()
    {
        //Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        if(transform.position.x > -4)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Vector3 moveDirection = new Vector3(-1.0f, 0.0f, 0.0f);
                transform.position += moveDirection * speed;
            }
        }

        if(transform.position.x < -1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Vector3 moveDirection = new Vector3(1.0f, 0.0f, 0.0f);
                transform.position += moveDirection * speed;
            }
        }

        if (transform.position.z < 4)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Vector3 moveDirection = new Vector3(0.0f, 0.0f, 1.0f);
                transform.position += moveDirection * speed;
            }
        }
        if (transform.position.z > 1)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Vector3 moveDirection = new Vector3(0.0f, 0.0f, -1.0f);
                transform.position += moveDirection * speed;
            }
        }
            

        ////xDirection = Input.GetAxis("Horizontal");
        ////zDirection = Input.GetAxis("Vertical");

    }
}
