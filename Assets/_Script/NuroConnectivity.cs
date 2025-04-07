using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuroConnectivity : MonoBehaviour
{
    public float nuroScanRange;
    // Start is called before the first frame update
    public Collider[] hits;
    public HackableObject hackableObject = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkRange();
    }

    void checkRange()
    {
        //isNearToDevice = Physics.CheckSphere(nurolinkPrefab.transform.position, nuroLinkRange, hackableMask);
       hits = Physics.OverlapSphere(transform.position, nuroScanRange);

        foreach (Collider hit in hits)
        {
            if (hit.GetComponent<HackableObject>())
            {
                //Debug.Log("Found the hackable device: " + hit.gameObject.name);
                // Do something with the specific object

                hackableObject = hit.gameObject.GetComponent<HackableObject>();
                if (Input.GetKeyDown(KeyCode.H)) 
                {
                    hackableObject.Hack();
                }
                
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;


        // Draw CheckSphere at the position of the spawned enemy
        Gizmos.DrawWireSphere(transform.position, nuroScanRange);


    }
}
