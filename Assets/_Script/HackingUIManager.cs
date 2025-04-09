using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.VisualScripting;

public class HackingUIManager : MonoBehaviour
{
    public static HackingUIManager Instance;

    [Header("Panels")]
    public GameObject hackPromptPanel;
    public GameObject detonatorUIPanel;
    public GameObject optionPanelTypeB;
    public GameObject optionPanelTypeC;

    [Header("Hacking System")]
    public Button yesButton;
    public Button noButton;

    [Header("Detonator Option")]
    public Button blastButton;
    public Button checkDetonatorcodeButton;
    public string DetonatorpcorrectCode;
    public TMP_InputField inputTextFieldDetonator;

    [Header("Computer Option")]
    public Button cryptoButton;
    public Button codeButton;
    public Button checkComputercodeButton;
    public string ComputercorrectCode = "mypassword123";
    public TMP_InputField inputTextFieldComp;

    [Header("Light Option")]
    public Button redButton;
    public Button yellowButton;
    public Button greenButton;
    public Button checkLightcodeButton;
    public string lightpcorrectCode = "mypassword123";
    public TMP_InputField inputTextFieldLight;

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