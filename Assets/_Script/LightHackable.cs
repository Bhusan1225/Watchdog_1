using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHackable : HackableObject
{
    public override void ShowHackOptions()
    {
        HackingUIManager.Instance.HideAllHackOptionPanels();
        HackingUIManager.Instance.optionPanelTypeB.SetActive(true);
    }
}
