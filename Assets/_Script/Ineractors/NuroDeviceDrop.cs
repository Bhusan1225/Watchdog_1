using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuroDeviceDrop : MonoBehaviour
{
    /// <summary>
    /// Nuro Drop is a script that handles the drop of nurolink gadget near the device you want to hack.This will drop by the player's companioun-dog.
    /// </summary>

    [SerializeField] GameObject nurolinkPrefab;
    [SerializeField] Transform nuroDrop;

    private GameObject nurolinkInstance;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            nurolinkInstance = Instantiate(nurolinkPrefab, nuroDrop.position, nuroDrop.rotation);
            Destroy(nurolinkInstance, 30f);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.GetComponent<HackableObject>() != null)
    //    {
    //        if (Input.GetKeyDown(KeyCode.X))
    //        {
    //            nurolinkInstance = Instantiate(nurolinkPrefab, nuroDrop.position, nuroDrop.rotation);
    //            Destroy(nurolinkInstance, 30f);
    //        }
    //    }
    //}
}
