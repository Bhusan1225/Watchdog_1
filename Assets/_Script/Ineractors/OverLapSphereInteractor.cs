using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLapSphereInteractor : MonoBehaviour
{

    [SerializeField] float scanRange;
    [SerializeField] Collider[] hits;
    [SerializeField] HackableObject hackableObject = null;

    // Update is called once per frame
    void Update() => checkRange();
 
    void checkRange()
    {
        //isNearToDevice = Physics.CheckSphere(nurolinkPrefab.transform.position, nuroLinkRange, hackableMask);
        hits = Physics.OverlapSphere(transform.position, scanRange);

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Draw CheckSphere at the position of the spawned enemy
        Gizmos.DrawWireSphere(transform.position, scanRange);

    }
}

