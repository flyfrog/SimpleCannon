using UnityEngine;
using Zenject;
 

public class InitGameManager :  IInitializable
{
    private PauseManager _pauseManager;
    
    [Inject]
    public InitGameManager(PauseManager pauseManagerArg)
    {
        _pauseManager = pauseManagerArg;
    }


    public void Initialize()
    {
        _pauseManager.PauseOn();
    }
}