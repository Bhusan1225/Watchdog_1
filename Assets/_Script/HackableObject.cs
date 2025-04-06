using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HackableObject : MonoBehaviour
{
    //public static HackableObject instance;

    //private void Awake()
    //{
    //    if (instance != null && instance != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        instance = this;
    //    }
    //}




    public abstract void hack();
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
