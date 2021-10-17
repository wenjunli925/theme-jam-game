using UnityEngine;

public class DecisionMaking : MonoBehaviour
{
    public PlayerMovement movement;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            movement.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            movement.enabled = true;
        }
    }
}
