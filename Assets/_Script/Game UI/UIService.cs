using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
 
    [SerializeField] GameObject cameraViewUI;
    [SerializeField] GameObject dotPanel;

    [SerializeField] GameObject codeUI;

    [SerializeField] internal CameraController theCamera;

    [SerializeField] internal Button firstPersonViewButton;
    [SerializeField] internal Button thirdPersonViewButton;

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

   /// <summary>
   /// Camera view
   /// </summary>
    public void ActivateCamaraViewUI(bool isAcivated)
    {
        cameraViewUI.SetActive(isAcivated);
        GameService.Instance.SoundService.PlaySoundEffects(SoundType.UIPopup);
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
    /// <summary>
    /// Computer cheatCode
    /// </summary>
    
    public void ShowCheatCode(bool showCode)
    {
        codeUI.SetActive(showCode);
        GameService.Instance.SoundService.PlaySoundEffects(SoundType.GadgetInternalSound);
    }


}
