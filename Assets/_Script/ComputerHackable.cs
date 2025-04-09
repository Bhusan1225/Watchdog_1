using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComputerHackable : HackableObject
{

    [Header("Steal crypto")]
    public int crypto = 5000;
    [SerializeField] private TextMeshProUGUI cryptoText;

    [Header("Steal codes")]
    [SerializeField] private GameObject codeHolder;
    public List<string> codes = new List<string>();
    private List<GameObject> CODES = new List<GameObject>();

    //animation
    public Animator popupAnimator;
    private bool isCryptoAdded = false;

    public override void ShowHackOptions()
    {
        HackingUIManager.Instance.HideAllHackOptionPanels();
        HackingUIManager.Instance.optionPanelTypeC.SetActive(true);
    }
    public override void CloseAction()
    {
        HackingUIManager.Instance.optionPanelTypeC.SetActive(false);
    }
    private void Start()
    {
        cryptoText.text = "Crypto: " + crypto.ToString();

        codes.Add("DET123");
        codes.Add("MIT173");
        codes.Add("GHI789");
        codes.Add("LIT123");


        for (int i = 0; i < codeHolder.transform.childCount; i++) 
        { 
            CODES.Add(codeHolder.transform.GetChild(i).gameObject);

        }
    }
  
    public override void Action1()
    {
        AddCrypto();
       

    }
    public void AddCrypto()
    {
        crypto += 30;
        cryptoText.text = "Crypto: " + crypto.ToString();
        isCryptoAdded = true;

        if (isCryptoAdded)
        {
            popupAnimator.SetBool("POPUP", true);
            isCryptoAdded = false; // Reset the flag right after triggering
            StartCoroutine(ResetPopupBool()); // Reset the animator bool after a short delay
        }
    }

    private IEnumerator ResetPopupBool()
    {
        yield return new WaitForSeconds(1f); // Wait for the popup animation duration
        popupAnimator.SetBool("POPUP", false); // Reset the animation flag
    }

    public override void Action2()
    {
        

        for (int i = 0; i < codes.Count && i < CODES.Count; i++)
        {
            TextMeshProUGUI textComponent = CODES[i].GetComponent<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = codes[i];
            }
            else
            {
                Debug.LogWarning("TextMeshProUGUI component missing on GameObject: " + CODES[i].name);
            }
        }
    }

   
    public override void Action3()
    {
        Debug.Log("Action 3- there is no function, you can add in the script if you want");

    }
}
