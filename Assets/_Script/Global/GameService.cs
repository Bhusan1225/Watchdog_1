using Controller;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameService :GenericMonoSingleton<GameService>
{
    //property
    public IntractorService interactionService { get; private set; }//connecting... InteractorService

    public SoundService SoundService { get; private set; }//connecting... SoundService

    [SerializeField]
    private HackingUIService hackingUIService;
    public HackingUIService HackingUIService => hackingUIService;//connecting... HackingUIService



    //Sound Referneces:
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource BGSource;
    // Start is called before the first frame update
    void Start()
    {
        interactionService = new IntractorService();
        SoundService = new SoundService(soundScriptableObject, SFXSource, BGSource);
    }

    // Update is called once per frame
    void Update()
    {
        interactionService.Update();
    }
}
