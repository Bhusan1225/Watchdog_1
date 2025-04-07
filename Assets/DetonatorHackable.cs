using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonatorHackable : HackableObject
{
    
    public override void ShowHackOptions()
    {
        Debug.Log("you are insinde the detonator");
        HackingUIManager.Instance.HideAllHackOptionPanels();
        Debug.Log("you are insinde the hideallhackOptionPanel");
        HackingUIManager.Instance.detonatorUIPanel.SetActive(true);
       
    }
}
