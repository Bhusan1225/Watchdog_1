using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    public Transform target;
    public float x;
    public float y;
    public float gap = 2f;

    float rotX;
    float rotY;

    public float minVarAngle = -45f;
    public float maxVarAngle = 45f;

    


    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
       
    }

    // Update is called once per frame
    void Update()
    {

        rotX += Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, minVarAngle, maxVarAngle);
        rotY += Input.GetAxis("Mouse X");

        var targetRotation = Quaternion.Euler(rotX, rotY, 0);

        //transform.position = target.position - targetRotation *new Vector3(x, y, gap);
        transform.position = target.position -  new Vector3(x, y, gap);
        //transform.rotation = targetRotation;

    }

   
}
