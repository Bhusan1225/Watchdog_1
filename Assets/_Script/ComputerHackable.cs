using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerHackable : HackableObject
{
    public override void ShowHackOptions()
    {
        HackingUIManager.Instance.HideAllHackOptionPanels();
        HackingUIManager.Instance.optionPanelTypeC.SetActive(true);
    }

    public override void Action1()
    {
        //will add logic later

    }
}
