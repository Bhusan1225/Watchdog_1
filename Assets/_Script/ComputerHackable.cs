using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerHackable : HackableObject
{
    public GameObject hackingPanel;
    public override void hack()
    {
        Debug.Log("hacking will happen in 10s");
        hackingPanel.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
