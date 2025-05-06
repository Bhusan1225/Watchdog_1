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
    public IntractorService(Camera _playerCamera, HackableObject _hackableObject, float _scanRange, Collider[] _hits, Transform _playerTransform)
    {
        this.playerCamera = _playerCamera;
        this.hackableObject = _hackableObject;
        this.hits = _hits;
        this.scanRange = _scanRange;
        this.playerTransform = _playerTransform;
    }


    // Update is called once per frame
    public void Update()
    {
        RayInteractor();
        CheckRange();
    }

    public void RayInteractor()
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


    public void CheckRange()
    {
        //isNearToDevice = Physics.CheckSphere(nurolinkPrefab.transform.position, nuroLinkRange, hackableMask);
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
