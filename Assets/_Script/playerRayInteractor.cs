using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRayInteractor : MonoBehaviour
{
    public Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the center of the screen in viewport space (0,0 is bottom-left, 1,1 is top-right)
        Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f);

        // Convert to a world-space ray
        Ray ray = camera.ViewportPointToRay(screenCenter);
      

        // Perform the raycast and check if it hits something
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.rigidbody != null && hit.transform.CompareTag("Hackable"))
            {
                Debug.DrawRay(ray.origin, ray.direction * 200f, Color.green); // Green for "Hackable" objects
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * 200f, Color.yellow); // Yellow for non-Hackable hits
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 200f, Color.red); // Red if nothing is hit
        }
    }
}
