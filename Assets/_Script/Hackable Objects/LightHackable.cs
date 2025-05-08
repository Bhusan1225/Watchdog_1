using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHackable : HackableObject
{
    [Header("TrafficLight")]
    [SerializeField] Renderer redLightRender;
    [SerializeField] Renderer yelloLightRender;
    [SerializeField] Renderer greenLightRender;

    private bool isRed;
    private bool isYellow;
    private bool isGreen;

    private void Start() => isRed = true;

    public override void CloseAction() => GameService.Instance.HackingUIService.optionPanelTypeB.SetActive(false);

    public override void ShowHackOptions()
    {
        GameService.Instance.HackingUIService.HideAllHackOptionPanels();
        GameService.Instance.HackingUIService.optionPanelTypeB.SetActive(true);
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
