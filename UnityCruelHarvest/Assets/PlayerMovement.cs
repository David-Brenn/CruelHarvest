using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    [Header("Movement")]
    public float moveSpeed = 6f;

    public float groundDrag;

    public float jumpForce = 5f;
    public float jumpCooldown = 0.25f;
    public float airMultiplier = 0.4f;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundMask;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
       
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded){
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
        
    }

    private void MovePlayer(){
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        

        if(grounded){
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        } else if(!grounded){
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
        
    }
    //This method lets the player move the atteched game object
    void Update()
    {
        //ground check   
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, groundMask);

         MyInput();
         SpeedControl();

        //handle drag
        if(grounded){
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0f;
        }

    }

    void FixedUpdate() {
         MovePlayer();
    }

    private void SpeedControl(){
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed){
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump(){

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump(){
        readyToJump = true;
    }
}
