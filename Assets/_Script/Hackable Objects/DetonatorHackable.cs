using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class DetonatorHackable : HackableObject
{
    [SerializeField] ParticleSystem blastParticle;
    [SerializeField] Transform blastPostion;

    private ParticleSystem blastParticleInstance;
    public override void ShowHackOptions()
    {
        GameService.Instance.HackingUIService.HideAllHackOptionPanels();
        GameService.Instance.HackingUIService.detonatorUIPanel.SetActive(true);
    }

    public override void CloseAction() => GameService.Instance.HackingUIService.detonatorUIPanel.SetActive(false);
   
    public override void Action1() 
    {
        Debug.Log("detonator- BOOM-BOOM-BOOM-BOOM");
        BlastParticleEffect();
        DetonatorBlastEffect();
    }

    private void BlastParticleEffect()=> blastParticleInstance = Instantiate(blastParticle, blastPostion.position, Quaternion.identity);
   
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

    public override void Action2() => Debug.Log("Action 2 - There is no functionality");
 
    public override void Action3() => Debug.Log("Action 3 - There is no functionality");
    
}
