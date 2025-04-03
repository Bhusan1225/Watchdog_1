using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;
    public GameObject cameraViewUI;

    public Button firstPersonViewButton;
    public Button thirdPersonViewButton;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject);  
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        cameraViewUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.C))
        {
            cameraViewUI.SetActive(true);

        }
        if ( Input.GetKeyDown(KeyCode.V))
        {
            cameraViewUI.SetActive(false);
        }

        firstPersonViewButton.onClick.AddListener(firstPersonViewButtonClicked);
        thirdPersonViewButton.onClick.AddListener(thirdPersonViewButtonClicked);

    }

    void firstPersonViewButtonClicked()
    {
        CameraController.instance.isThirdPersonActive = false;
    }


    void thirdPersonViewButtonClicked() 
    {
        CameraController.instance.isThirdPersonActive = true;
    }

}
