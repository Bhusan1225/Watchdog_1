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

    private GameObject nurolinkInstance;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            nurolinkInstance= Instantiate(nurolinkPrefab, nuroDrop.position, nuroDrop.rotation);
            Destroy(nurolinkInstance, 20f);
        }


    }

    
}
