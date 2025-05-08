using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] GameObject cameraViewUI;
    [SerializeField] GameObject dotPanel;

    [SerializeField] internal CameraController theCamera;

    [SerializeField] internal Button firstPersonViewButton;
    [SerializeField] internal Button thirdPersonViewButton;


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
        dotPanel.SetActive(false);
       
    }
    private void OnEnable()
    {
        firstPersonViewButton.onClick.AddListener(firstPersonViewButtonClicked);
        thirdPersonViewButton.onClick.AddListener(thirdPersonViewButtonClicked);
    }

    private void OnDisable()
    {
        firstPersonViewButton.onClick.RemoveListener(firstPersonViewButtonClicked);
        thirdPersonViewButton.onClick.RemoveListener(thirdPersonViewButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.C))
        {
            cameraViewUI.SetActive(true);
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.UIPopup);

        }
        if ( Input.GetKeyDown(KeyCode.V))
        {
            cameraViewUI.SetActive(false);
        }

    }

    void firstPersonViewButtonClicked()
    {
        theCamera.isThirdPersonActive = false;
        dotPanel.SetActive(true);
        GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
    }


    void thirdPersonViewButtonClicked() 
    {
        theCamera.isThirdPersonActive = true;
        dotPanel.SetActive(false);
        GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
    }

}
