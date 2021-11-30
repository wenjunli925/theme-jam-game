using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.1f;

    public AudioFeedback feedback;

    InputActions actions;

    private void Awake()
    {
        actions = new InputActions();

        actions.Player.Up.performed += ctx => MoveUp();
        actions.Player.Down.performed += ctx => MoveDown();
        actions.Player.Left.performed += ctx => MoveLeft();
        actions.Player.Right.performed += ctx => MoveRight();
        actions.Player.LastYear.performed += ctx => MovetoLastYear();
        actions.Player.NextYear.performed += ctx => MovetoNextYear();
    }

    void MoveUp()
    {
        if (transform.position.z < 4)
        {
                Vector3 moveDirection = new Vector3(0.0f, 0.0f, 1.0f);
                transform.position += moveDirection * speed;
                feedback.isUnlocked = true;

            feedback.wall = false;
        } else
        {
            feedback.wall = true;
        }
    }

    void MoveDown()
    {
        if (transform.position.z > 1 && transform.position.x > -5)
        {
                Vector3 moveDirection = new Vector3(0.0f, 0.0f, -1.0f);
                transform.position += moveDirection * speed;
                feedback.isUnlocked = true;

            feedback.wall = false;
        }
        else
        {
            feedback.wall = true;
        }
    }

    void MoveLeft()
    {
        if (transform.position.x > -4)
        {
                Vector3 moveDirection = new Vector3(-1.0f, 0.0f, 0.0f);
                transform.position += moveDirection * speed;
                feedback.isUnlocked = true;

            feedback.wall = false;
        }
        else
        {
            feedback.wall = true;
        }
    }

    void MoveRight()
    {
        if (transform.position.x < -1)
        {
                Vector3 moveDirection = new Vector3(1.0f, 0.0f, 0.0f);
                transform.position += moveDirection * speed;
                feedback.isUnlocked = true;

            feedback.wall = false;
        }
        else
        {
            feedback.wall = true;
        }
    }

    void MovetoLastYear()
    {
        if (transform.position.y < 4.5 && transform.position.x > -5)
        {
            Vector3 moveDirection = new Vector3(0.0f, 1.0f, 0.0f);
            transform.position += moveDirection * speed;
            feedback.isUnlocked = true;

            feedback.wall = false;
        }
        else
        {
            feedback.wall = true;
        }
    }

    void MovetoNextYear()
    {
        if (transform.position.y > 0.5 && transform.position.x > -5)
        {
            Vector3 moveDirection = new Vector3(0.0f, -1.0f, 0.0f);
            transform.position += moveDirection * speed;
            feedback.isUnlocked = true;

            feedback.wall = false;
        }
        else
        {
            feedback.wall = true;
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

    // Update is called once per frame
    void Update()
    {

        //if (transform.position.x > -4)
        //{
        //    if (Input.GetKeyDown(KeyCode.LeftArrow))
        //    {
        //        Vector3 moveDirection = new Vector3(-1.0f, 0.0f, 0.0f);
        //        transform.position += moveDirection * speed;
        //    }
        //}

        //if (transform.position.x < -1)
        //{
        //    if (Input.GetKeyDown(KeyCode.RightArrow))
        //    {
        //        Vector3 moveDirection = new Vector3(1.0f, 0.0f, 0.0f);
        //        transform.position += moveDirection * speed;
        //    }
        //}

        //if (transform.position.z < 4)
        //{
        //    if (Input.GetKeyDown(KeyCode.UpArrow))
        //    {
        //        Vector3 moveDirection = new Vector3(0.0f, 0.0f, 1.0f);
        //        transform.position += moveDirection * speed;
        //    }
        //}
        //if (transform.position.z > 1 && transform.position.x > -5)
        //{
        //    if (Input.GetKeyDown(KeyCode.DownArrow))
        //    {
        //        Vector3 moveDirection = new Vector3(0.0f, 0.0f, -1.0f);
        //        transform.position += moveDirection * speed;
        //    }
        //}


    }
}
