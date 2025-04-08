using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class HackingUIManager : MonoBehaviour
{
    public static HackingUIManager Instance;

    [Header("Panels")]
    public GameObject hackPromptPanel;
    public GameObject detonatorUIPanel;
    public GameObject optionPanelTypeB;
    public GameObject optionPanelTypeC;

    public Button yesButton;
    public Button noButton;

    [Header("Bomb Option")]
    public Button blastButton;

    [Header("Computer Option")]

    [Header("Light Option")]
    public Button redButton;
    public Button yellowButton;
    public Button greenButton;


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
        
        yesButton.onClick.AddListener(OnConfirmHack);
        noButton.onClick.AddListener(OnDeclineHack);
    }

    // Called when user confirms hacking
    public void OnConfirmHack()
    {
        hackPromptPanel.SetActive(false);
        currentObject.ShowHackOptions();

        ActiveBombButtons();
        ActiveTrafficButtons();

        
    }

    void ActiveBombButtons()
    {
        //bomb
        blastButton.onClick.AddListener(Action1);

    }

    void ActiveTrafficButtons()
    {
        //traffic Light
        redButton.onClick.AddListener(Action1);
        yellowButton.onClick.AddListener(Action2);
        greenButton.onClick.AddListener(Action3);
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