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

    public override void Action2()
    {

        Debug.Log("Action 2 - there is no function, you can add in the script if you want");


    }

    public override void Action3()
    {
        Debug.Log("Action 3- there is no function, you can add in the script if you want");

    }
}
