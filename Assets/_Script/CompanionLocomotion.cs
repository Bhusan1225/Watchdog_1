using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionLocomotion : MonoBehaviour
{
    public CharacterMovement playerMovement;
    public CharacterMovement dogMovement;
    public ChaseAI dogchase;

    public GameObject playerCamera;
    public GameObject dogCamera;



    // Start is called before the first frame update
    void Start()
    {
        dogCamera.SetActive(false);
        //dogMovement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            playerCamera.SetActive(false);
            playerMovement.enabled = false;
            dogchase.enabled = false;
            
            dogMovement.isWatchdogActivated = true;

            dogCamera.SetActive(true);

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            playerCamera.SetActive(true);
            playerMovement.enabled = true;
            dogchase.enabled = true;
            dogMovement.isWatchdogActivated = false;

            dogCamera.SetActive(false);

        }
    }
}
