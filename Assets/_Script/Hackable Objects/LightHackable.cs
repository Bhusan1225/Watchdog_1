using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHackable : HackableObject
{
    [Header("TrafficLight")]
    public Renderer redLightRender;
    public Renderer yelloLightRender;
    public Renderer greenLightRender;

    

    bool isRed;
    bool isYellow;
    bool isGreen;
    private void Start()
    {
        isRed = true;
        
    }

    public override void CloseAction()
    {
        HackingUIManager.Instance.optionPanelTypeB.SetActive(false);
    }

 
    public override void ShowHackOptions()
    {
        HackingUIManager.Instance.HideAllHackOptionPanels();
        HackingUIManager.Instance.optionPanelTypeB.SetActive(true);
    }

    public override void Action1()
    {
        isRed = true;
        isYellow = false;
        isGreen = false;
        if (isRed && redLightRender != null && yelloLightRender != null && greenLightRender != null)
        {
            redLightRender.material.color = Color.red;
            yelloLightRender.material.color = Color.gray;
            greenLightRender.material.color = Color.gray;


        }
    }

    public override void Action2()
    {
        isRed = false;
        isYellow = true;
        isGreen = false;

        if (isYellow && redLightRender != null && yelloLightRender != null && greenLightRender != null)
        {

            redLightRender.material.color = Color.gray;
            yelloLightRender.material.color = Color.yellow;
            greenLightRender.material.color = Color.gray;
        }
        


    }

    public override void Action3()
    {
        isRed = false;
        isYellow = false;
        isGreen = true;

        if (isGreen && redLightRender != null && yelloLightRender != null && greenLightRender != null)
        {
            redLightRender.material.color = Color.gray;
            yelloLightRender.material.color = Color.gray;
            greenLightRender.material.color = Color.green;
        }


    }
}
