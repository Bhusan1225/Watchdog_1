using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   

    public Transform target;
    public float gap = 2f;

    float rotX;
    float rotY;

    public float minVarAngle = -45f;
    public float maxVarAngle =  45f;

    public bool isThirdPersonActive;


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
        
        transform.position = target.position - targetRotation * new Vector3(0f, 0f, gap);
        transform.rotation = targetRotation;
    }

    public void firstPerson()
    {
        var targetRotation = Quaternion.Euler(rotX, rotY, 0);

        Vector3 targetPosition = target.position;

        transform.position = targetPosition - targetRotation * new Vector3(0f, -1.4f, 0f);
        transform.rotation = targetRotation;

        target.rotation = targetRotation;
    }

    public Quaternion flatRoation => Quaternion.Euler(0, rotY, 0);
}
