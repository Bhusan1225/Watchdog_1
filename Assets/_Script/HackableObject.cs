using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HackableObject : MonoBehaviour
{
   

    public void Hack()
    {
        // Ask UI Manager to show confirmation
        HackingUIManager.Instance.ShowHackPrompt(this);
    }

    // This will be implemented by child classes to show specific options
    public abstract void ShowHackOptions();

    //public abstract void Action1();
}
