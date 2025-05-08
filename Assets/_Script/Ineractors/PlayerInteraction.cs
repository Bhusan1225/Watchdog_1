using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("SphereInteractor")]
    [SerializeField] float scanRange;
    [SerializeField] Collider[] hits;
    [SerializeField] HackableObject hackableObject = null;
    [SerializeField] Transform PlayerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    //Debug.Log("Player collided with a hackable object");
    //

    private void Update()
    {
        GameService.Instance.interactionService.SphereInteractor(PlayerTransform, hits, hackableObject, scanRange); // press H
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Draw CheckSphere at the position of the spawned enemy
        Gizmos.DrawWireSphere(PlayerTransform.position, scanRange);

    }
}
