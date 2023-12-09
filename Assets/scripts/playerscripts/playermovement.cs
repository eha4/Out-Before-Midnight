using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Transform crouch;
     public Transform standing;
    // public GameObject crouchpos;
    // public GameObject standpos;
    //private float yposOr;
    //private float xposOr;
    //private float zposOr;
    //private float yposCr;
    //private float xposCr;
    // private float zposCr;
    public float crouchWalkSpeed = 5.0f;
    public float standingWalkSpeed = 7.5f;
    private float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    private bool crouched;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    private KeyCode crouchkey = KeyCode.LeftControl;
    [HideInInspector]
    public bool canMove = true;
    private bool ismoving;
    private Transform curPos;
    private Transform lastpos;
    private float movement;
    private AudioSource walking;
    void Start()
    {
        walking = gameObject.GetComponent<AudioSource>();
        walkingSpeed = standingWalkSpeed;
        //crouch = crouchpos.transform; 
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //float magnitude = gameObject.GetComponent<CharacterController>().attachedRigidbody.velocity.magnitude;
        //movement = magnitude; 
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
       {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if(crouched == false && Input.GetKeyDown(crouchkey))
        {
            walkingSpeed = crouchWalkSpeed;
            playerCamera.transform.position = crouch.transform.position;
            crouched = true;
            characterController.radius = .3f;
            characterController.height = 1.5f;
        }
        else if (crouched == true && Input.GetKeyDown(crouchkey))
        {
            walkingSpeed = standingWalkSpeed;
            playerCamera.transform.position = standing.transform.position;
            crouched = false;
            characterController.radius = .3f;
            characterController.height = 1.4f;
        }
        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        if (characterController.velocity.magnitude > .1)
        {
            ismoving = true;
        }
        else
            ismoving = false;
        if(ismoving == true && !walking.isPlaying)
        {
            walking.Play();
            
        }
        //Debug.Log(characterController.velocity.magnitude);
    }
}