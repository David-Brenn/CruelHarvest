using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public CharacterController controller;

    public float speed = 12f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //This method lets the player move the atteched game object
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical") ;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //If the player presses the space bar, the player will jump
        //The player will only jump if the player is on the ground
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            move.y = 1f;
        }

    }
}
