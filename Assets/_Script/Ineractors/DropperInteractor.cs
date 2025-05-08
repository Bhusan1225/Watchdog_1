using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperInteractor : MonoBehaviour
{

    [SerializeField] float scanRange;
    [SerializeField] Collider[] hits;
    [SerializeField] HackableObject hackableObject = null;
    
    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HackableObject>() != null)
        {
            GameService.Instance.interactionService.SphereInteractor(this.transform, hits, hackableObject, scanRange);// press H
        }
    }

}
