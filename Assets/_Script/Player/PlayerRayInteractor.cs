using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayInteractor : MonoBehaviour
{
    public static PlayerRayInteractor instance;

    [SerializeField] Camera theCamera;
    [SerializeField] HackableObject hackableObject = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {

        RayInteractor();
       
    }

    private void RayInteractor()
    {
        Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f);
        Ray ray = theCamera.ViewportPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            // Check if object is "Hackable"
            if (hitObject.GetComponent<HackableObject>())
            {
                hackableObject = hitObject.GetComponent<HackableObject>();
                hackableObject.GetComponent<Outline>().enabled = true;
                if (Input.GetKeyDown(KeyCode.H))
                {
                    hackableObject.Hack();
                }
            }
            else
            {
                if (hackableObject)
                {
                    hackableObject.GetComponent<Outline>().enabled = false;
                }
            }
        }
    }
}

