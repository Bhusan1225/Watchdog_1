using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public static CameraController instance;

    public Transform player;
    public float gap = 2f;

    float rotX;
    float rotY;

    public float minVarAngle = -45f;
    public float maxVarAngle =  45f;

    public bool isThirdPersonActive;

    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        isThirdPersonActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        rotX += Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, minVarAngle, maxVarAngle);
        rotY += Input.GetAxis("Mouse X");



        if (isThirdPersonActive)
        {
        
            thirdPerson();
        }
        else
        {
           
            
            firstPerson();
        }

    }


    public void thirdPerson()
    {
        var targetRotation = Quaternion.Euler(rotX, rotY, 0);
        
        Vector3 playerPosition = player.position;

        transform.position = playerPosition - targetRotation * new Vector3(0f, 0f, gap);
        transform.rotation = targetRotation;
    }

    public void firstPerson()
    {
        var targetRotation = Quaternion.Euler(rotX, rotY, 0);

        Vector3 playerPosition = player.position;

        transform.position = playerPosition - targetRotation * new Vector3(0f, -1.4f, 0f);
        transform.rotation = targetRotation;

        player.rotation = targetRotation;
    }
}
