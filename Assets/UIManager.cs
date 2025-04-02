using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    public GameObject cameraViewUI;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate instances
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
        if( Input.GetKeyDown(KeyCode.Escape))
        {
            cameraViewUI.SetActive(true);

        }
        
    }
}
