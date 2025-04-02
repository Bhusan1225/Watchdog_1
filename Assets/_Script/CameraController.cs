using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public float gap = 2f;

    float rotX;
    float rotY;

    public float minVarAngle = -45f;
    public float maxVarAngle =  45f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        rotX += Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, minVarAngle, maxVarAngle);
        rotY += Input.GetAxis("Mouse X");

        firstPersonCamera();


    }


    public void thirdpersonCamera()
    {
        var targetRotation = Quaternion.Euler(rotX, rotY, 0);
        
        Vector3 playerPosition = player.position;

        transform.position = playerPosition - targetRotation * new Vector3(0f, 0f, gap);
        transform.rotation = targetRotation;
    }

    public void firstPersonCamera()
    {
        var targetRotation = Quaternion.Euler(rotX, rotY, 0);
        
        Vector3 playerPosition = player.position;
        Vector3 cameraPosition = transform.position;

        transform.position = playerPosition - targetRotation * new Vector3(0f, 0f, gap);
        transform.rotation = targetRotation;
    }
}
