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

  
    public override void ShowHackOptions()
    {
        HackingUIManager.Instance.HideAllHackOptionPanels();
        HackingUIManager.Instance.optionPanelTypeC.SetActive(true);
    }

    private void Start()
    {
        cryptoText.text = "Crypto: " + crypto.ToString();

        codes.Add("ABC123");
        codes.Add("DEF456");
        codes.Add("GHI789");

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
