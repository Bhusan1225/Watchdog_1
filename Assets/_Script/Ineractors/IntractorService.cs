using UnityEngine;

public class IntractorService 
{   
    //Ray Interactor
    private Camera playerCamera;

    //OverlapSphere Interactor
    private float scanRange;
    private Collider[] hits;
    private Transform playerTransform;


    private HackableObject hackableObject = null;
    public IntractorService()
    {
             
    }


    // Update is called once per frame
    public void Update()
    {
       // RayInteractor(playerCamera);
        //SphereInteractor(playerTransform, hits, hackableObject, scanRange);
    }

    public void RayInteractor(Camera _playerCamera)
    {
        Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f);
        Ray ray = playerCamera.ViewportPointToRay(screenCenter);

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


    public void SphereInteractor(Transform playerTransform, Collider[] hits, HackableObject hackableObject, float scanRange)
    {
        
        hits = Physics.OverlapSphere(playerTransform.position, scanRange);

        foreach (Collider hit in hits)
        {
            if (hit.GetComponent<HackableObject>())
            {
                //Debug.Log("Found the hackable device: " + hit.gameObject.name);
                //Do something with the specific object

                hackableObject = hit.gameObject.GetComponent<HackableObject>();
                if (Input.GetKeyDown(KeyCode.H))
                {
                    hackableObject.Hack();
                }

            }
        }
    }
}
