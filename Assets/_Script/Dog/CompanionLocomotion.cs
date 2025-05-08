using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionLocomotion : MonoBehaviour
{
    [SerializeField] CharacterController1 playerMovement;
    [SerializeField] CharacterController1 dogMovement;
    [SerializeField] ChaseAI dogchase;

    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject dogCamera;
   


    // Start is called before the first frame update
    void Start()
    {
        dogCamera.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            playerCamera.SetActive(false);
            playerMovement.enabled = false;
            dogchase.enabled = false;

            playerMovement.model.IsWatchdogActivated = true;
            dogMovement.model.IsWatchdogActivated = true;

            dogCamera.SetActive(true);

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            playerCamera.SetActive(true);
            playerMovement.enabled = true;
            dogchase.enabled = true;
            playerMovement.model.IsWatchdogActivated = false;
            dogMovement.model.IsWatchdogActivated = false;

            dogCamera.SetActive(false);

        }
    }
}
