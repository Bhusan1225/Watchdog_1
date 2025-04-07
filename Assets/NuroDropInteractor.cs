using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuroDropInteractor : MonoBehaviour
{
    /// <summary>
    /// Nuro Drop is a script that handles the drop of nurolink gadget near the device you want to hack.This will drop by the player's companioun-dog.
    /// </summary>

    public GameObject nurolinkPrefab;
    public Transform nuroDrop;

    public float nuroScanRange;

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        { 
            Instantiate(nurolinkPrefab, nuroDrop.position, nuroDrop.rotation);
            Invoke("checkRange", 1f);
        }


    }

    void checkRange()
    {
        //isNearToDevice = Physics.CheckSphere(nurolinkPrefab.transform.position, nuroLinkRange, hackableMask);
        Collider[] hits = Physics.OverlapSphere(nurolinkPrefab.transform.position, nuroScanRange);
        
        foreach (Collider hit in hits) 
        {
            if(hit.GetComponent<HackableObject>())
            {
                Debug.Log("Found the hackable device: " + hit.gameObject.name);
                // Do something with the specific object
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;


        // Draw CheckSphere at the position of the spawned enemy
        Gizmos.DrawWireSphere(nurolinkPrefab.transform.position, nuroScanRange);


    }
}
