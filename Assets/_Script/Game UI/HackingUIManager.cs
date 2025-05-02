using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HackingUIManager : MonoBehaviour
{
    public static HackingUIManager Instance;

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

    private void Awake()
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

    // Show "Do you want to hack?" popup
    public void ShowHackPrompt(HackableObject obj)
    {
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
        hackPromptPanel.SetActive(false);
        currentObject.ShowHackOptions();

        checkComputercodeButton.onClick.AddListener(ActiveComputerButtons);
        checkDetonatorcodeButton.onClick.AddListener(ActiveDetonatorButtons);
        checkLightcodeButton.onClick.AddListener(ActiveTrafficButtons);

    }


    void ActiveDetonatorButtons()
    {
        if (inputTextFieldDetonator.text == DetonatorpcorrectCode)
        {
            blastButton.onClick.RemoveAllListeners();
            blastButton.onClick.AddListener(Action1);
            closeButtonDet.onClick.AddListener(CloseAction);
        }
        else
        {
            Debug.Log("Detonate is not working");

        }
    }

    void ActiveTrafficButtons()
    {
        if (inputTextFieldLight.text == lightpcorrectCode)
        {
            redButton.onClick.RemoveAllListeners();
            yellowButton.onClick.RemoveAllListeners();
            greenButton.onClick.RemoveAllListeners();

            redButton.onClick.AddListener(Action1);
            yellowButton.onClick.AddListener(Action2);
            greenButton.onClick.AddListener(Action3);
            closeButtonlit.onClick.AddListener(CloseAction);
        }
        else
        {
            Debug.Log(" Light is not working");
        }
        
    }

    void ActiveComputerButtons()
    {
        
        if (inputTextFieldComp.text == ComputercorrectCode)
        {
            Debug.Log(" buttons are working");
            cryptoButton.onClick.RemoveAllListeners();
            codeButton.onClick.RemoveAllListeners();

            cryptoButton.onClick.AddListener(Action1);
            codeButton.onClick.AddListener(Action2);
            closeButtonPC.onClick.AddListener(CloseAction);

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
        currentObject.CloseAction();
    }

    public void OnDeclineHack()
    {
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