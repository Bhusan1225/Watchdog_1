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

        //bomb
        blastButton.onClick.AddListener(BlastBomb);
    }
    public void BlastBomb()
    {
        currentObject.Action1();
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