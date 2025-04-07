using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    public float speed = 3f;
    public float moveX;
    public float moveZ;
   
    public CameraController camera;
    public float rotSpeed = 600f;
    Quaternion requiredRotation;

    public Animator dogAnimator;
    public Animator playerAnimator;
    
    //grounded
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    Vector3 velocity;
    float gravity = -9.8f ;
    float movementAmout;

    //public bool isWatchdogActivated;
    public enum characterType
    {
        Player,
        Dog
    }

    public characterType characters;

    

    // Update is called once per frame
    void Update()
    {
        //ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //resetting the default velocity
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -5f;
        }
       

        // will give direction
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        
        //check if the target is moving
        movementAmout = Mathf.Clamp01(Mathf.Abs(moveX) + Mathf.Abs(moveZ));

        //combine this above 2 direction
        var movementInput = (new Vector3(moveX, 0, moveZ)).normalized;
        var movementDirection = camera.flatRoation * movementInput;

        if (movementAmout > 0)
        {
            transform.position += movementDirection * speed * Time.deltaTime;
            requiredRotation = Quaternion.LookRotation(movementDirection);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, requiredRotation, rotSpeed * Time.deltaTime); // for the smooth roation



        CharacterMovementAnimation();


    }



    public void CharacterMovementAnimation()
    {
        if (characters == characterType.Player )
        {
            playerAnimator.SetFloat("MOVEVALUE", movementAmout);
        }
        else if (characters == characterType.Dog)
        {
            dogAnimator.SetFloat("DOGMOVEVALUE", movementAmout);
        }
    }

}
