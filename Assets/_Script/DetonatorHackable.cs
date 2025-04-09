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
        BlastParticleEffect();
        DetonatorBlastEffect();

    }
    private void BlastParticleEffect()
    {
        blastParticleInstance = Instantiate(blastParticle, blastPostion.position, Quaternion.identity);
    }


    void DetonatorBlastEffect()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, 7);

        foreach (Collider Object in collider)
        {
            Rigidbody rb = Object.GetComponent<Rigidbody>();

            if (Object.GetComponent<Rigidbody>() != null && Object.CompareTag("BombBox"))
            {
                rb.AddExplosionForce(1000, transform.position, 7);
            }
            Destroy(this.gameObject);
        }
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
