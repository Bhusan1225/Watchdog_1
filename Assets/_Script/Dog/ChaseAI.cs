using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float gap = 2f;

    float rotX;
    float rotY;

    [SerializeField] float minVarAngle = -45f;
    [SerializeField] float maxVarAngle = 45f;


    void Update()
    {

        rotX += Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, minVarAngle, maxVarAngle);
        rotY += Input.GetAxis("Mouse X");

        var targetRotation = Quaternion.Euler(rotX, rotY, 0);

        transform.position = target.position -  new Vector3(x, y, gap);
       

    }

}
