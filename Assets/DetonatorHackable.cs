using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
