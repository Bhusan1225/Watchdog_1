using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class DetonatorHackable : HackableObject
{
    public ParticleSystem blastParticle;
    public Transform blastPostion;
    

    private ParticleSystem blastParticleInstance;
    public override void ShowHackOptions()
    {
        Debug.Log("you are insinde the detonator");
        HackingUIManager.Instance.HideAllHackOptionPanels();
        Debug.Log("you are insinde the hideallhackOptionPanel");
        HackingUIManager.Instance.detonatorUIPanel.SetActive(true);
       
    }
    public override void Action1() 
    {
        Debug.Log("detonator- BOOM-BOOM-BOOM-BOOM");
        SpawnBlastParticle();

    }
    private void SpawnBlastParticle()
    {
        blastParticleInstance = Instantiate(blastParticle, blastPostion.position, Quaternion.identity);
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
