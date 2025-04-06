using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    public float moveX;
    public float moveZ;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    void Movement()
    {
        // will give direction
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        //check if the player is moving
        float movementAmout = Mathf.Abs(moveX) + Mathf.Abs(moveZ);

        //combine this above 2 direction
        var movementInput = (new Vector3(moveX, 0, moveZ)).normalized;

        if (movementAmout > 0)
        {
            transform.position += movementInput * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(movementInput);
        }
    }
}
