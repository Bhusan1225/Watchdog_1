using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    public float moveX;
    public float moveZ;

    public bool isThirdPersonActive;

    public CameraController camera;


    // Start is called before the first frame update
    void Start()
    {
        isThirdPersonActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isThirdPersonActive)
        {
            ThridPersonMovement();
        }
        else
        {
            FirstPersonMovement();
        }
        

    }

    void ThridPersonMovement()
    {
        // will give direction
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        //check if the target is moving
        float movementAmout = Mathf.Abs(moveX) + Mathf.Abs(moveZ);

        //combine this above 2 direction
        var movementInput = (new Vector3(moveX, 0, moveZ)).normalized;
        var movementDirection = camera.flatRoation * movementInput;

        if (movementAmout > 0)
        {
            transform.position += movementDirection * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(movementDirection);
        }
    }
    void FirstPersonMovement()
    {
        // will give direction
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        
        //combine this above 2 direction
        Vector3 move = transform.forward * moveZ + transform.right * moveX;
        transform.position += move * speed * Time.deltaTime;
        
    }


}
