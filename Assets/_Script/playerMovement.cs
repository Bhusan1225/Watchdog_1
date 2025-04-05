using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 3f;

    private float moveX;
    private float moveZ;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();


    }

    void PlayerMovement()
    {
        // will give direction
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        //combine this above 2 direction
        var movementInput = (new Vector3(moveX, 0, moveZ)).normalized;

        float movementAmout = Mathf.Abs(moveX)  + Mathf.Abs(moveZ);

        if (movementAmout > 0)
        {
            transform.position += movementInput * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(movementInput);
        }
    }
}
