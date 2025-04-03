using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 3f;

    private float moveX;
    private float moveY;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // will give direction
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        //combine this above 2 direction
        Vector3 move  = transform.right * moveX + transform.forward * moveY;

        transform.position += move * speed * Time.deltaTime;



        //transform.position += 

        
    }
}
