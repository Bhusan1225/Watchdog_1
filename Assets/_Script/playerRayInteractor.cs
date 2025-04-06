using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayInteractor : MonoBehaviour
{
    static PlayerRayInteractor instance;

    public Camera camera;
    public  HackableObject hackableObject = null;

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
        Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f);
        Ray ray = camera.ViewportPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            // Check if object is "Hackable"
            if (hitObject.GetComponent<HackableObject>())
            {
                hackableObject = hitObject.GetComponent<HackableObject>();
                hackableObject.GetComponent<Outline>().enabled = true;
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

