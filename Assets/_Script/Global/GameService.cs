using Controller;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameService :GenericMonoSingleton<GameService>
{
    //property
    public IntractorService interactionService { get; private set; }//connecting... InteractorService

    [Header("Intractor")]
    [Header("Ray Intractor")]
    [SerializeField] Camera playerCamera;
    [SerializeField] HackableObject hackableObject = null;
    
    [Header("Sphere Intractor")]
    private float scanRange;
    private Collider[] hits;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        interactionService = new IntractorService(playerCamera,hackableObject, scanRange, hits, playerTransform);
    }

    // Update is called once per frame
    void Update()
    {
        interactionService.Update();
    }
}
