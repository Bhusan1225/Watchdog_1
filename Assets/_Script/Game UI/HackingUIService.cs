using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HackingUIService : MonoBehaviour
{

    [Header("Panels")]
    [SerializeField] GameObject hackPromptPanel;
    [SerializeField] internal GameObject detonatorUIPanel;
    [SerializeField] internal GameObject optionPanelTypeB;
    [SerializeField] internal GameObject optionPanelTypeC;

    [Header("Hacking System")]
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;
    

    [Header("Detonator Option")]
    [SerializeField] Button blastButton;
    [SerializeField] Button checkDetonatorcodeButton;
    [SerializeField] string DetonatorpcorrectCode;
    [SerializeField] TMP_InputField inputTextFieldDetonator;
    [SerializeField] Button closeButtonDet;

    [Header("Computer Option")]
    [SerializeField] Button cryptoButton;
    [SerializeField] Button codeButton;
    [SerializeField] Button checkComputercodeButton;
    [SerializeField] string ComputercorrectCode = "mypassword123";
    [SerializeField] TMP_InputField inputTextFieldComp;
    [SerializeField] Button closeButtonPC;

    [Header("Light Option")]
    [SerializeField] Button redButton;
    [SerializeField] Button yellowButton;
    [SerializeField] Button greenButton;
    [SerializeField] Button checkLightcodeButton;
    [SerializeField] string lightpcorrectCode = "mypassword123";
    [SerializeField] TMP_InputField inputTextFieldLight;
    [SerializeField] Button closeButtonlit;

    [Header("Hacked Object")]
    public HackableObject currentObject;

  
    // Show "Do you want to hack?" popup
    public void ShowHackPrompt(HackableObject obj)
    {
        GameService.Instance.SoundService.PlaySoundEffects(SoundType.GadgetPopup);
        currentObject = obj;
        hackPromptPanel.SetActive(true);
        
        // Clear listeners to avoid stacking
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(OnConfirmHack);
        noButton.onClick.AddListener(OnDeclineHack);

        
       
        
    }


    public void OnConfirmHack()
    {
        GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
        GameService.Instance.SoundService.PlaySoundEffects(SoundType.GadgetInternalSound);
        hackPromptPanel.SetActive(false);
        currentObject.ShowHackOptions();

        checkComputercodeButton.onClick.AddListener(ActiveComputerButtons);
        checkDetonatorcodeButton.onClick.AddListener(ActiveDetonatorButtons);
        checkLightcodeButton.onClick.AddListener(ActiveTrafficButtons);

    }


    void ActiveDetonatorButtons()
    {
        closeButtonDet.onClick.AddListener(CloseAction);
        if (inputTextFieldDetonator.text == DetonatorpcorrectCode)
        {
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
            blastButton.onClick.RemoveAllListeners();
            blastButton.onClick.AddListener(Action1);
           

        }
        else
        {
            Debug.Log("Detonate is not working");
        }
    }

    void ActiveTrafficButtons()
    {
        closeButtonlit.onClick.AddListener(CloseAction);
        if (inputTextFieldLight.text == lightpcorrectCode)
        {
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
            redButton.onClick.RemoveAllListeners();
            yellowButton.onClick.RemoveAllListeners();
            greenButton.onClick.RemoveAllListeners();

            redButton.onClick.AddListener(Action1);
            yellowButton.onClick.AddListener(Action2);
            greenButton.onClick.AddListener(Action3);
            
        }
        else
        {
            Debug.Log(" Light is not working");
        }
        
    }

    void ActiveComputerButtons()
    {
        closeButtonPC.onClick.AddListener(CloseAction);

        if (inputTextFieldComp.text == ComputercorrectCode)
        {
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
            Debug.Log(" buttons are working");
            cryptoButton.onClick.RemoveAllListeners();
            codeButton.onClick.RemoveAllListeners();

            cryptoButton.onClick.AddListener(Action1);
            codeButton.onClick.AddListener(Action2);
            

        }
        else
        {
            Debug.Log(" pc is not working");
           
        }
        
    }

    public void Action1()
    {
        currentObject.Action1();
    }

    public void Action2()
    {
        currentObject.Action2();
    }

    public void Action3()
    {
        currentObject.Action3();
    }

    public void CloseAction()
    {
        Debug.Log(" Close buttons are working");
        currentObject.CloseAction();
    }

    public void OnDeclineHack()
    {
        GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
        hackPromptPanel.SetActive(false);
    }

    // Optional: Close all hack option panels
    public void HideAllHackOptionPanels()
    {
        detonatorUIPanel.SetActive(false);
        optionPanelTypeB.SetActive(false);
        optionPanelTypeC.SetActive(false);
    }
}