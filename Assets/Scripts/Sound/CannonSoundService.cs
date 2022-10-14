using UnityEngine;
using UnityEngine.Playables;
using Zenject;

public class CannonSoundService : StandartAudioService 
{
    [SerializeField] private AudioClip _cannonFireClip;


    [Inject]
    public void Construct(CannonShotController cannonShotControllerArg)
    {
        cannonShotControllerArg.FiredEvent += PlayFire;
    }

    private void PlayFire()
    {
        PlayVariable(_cannonFireClip);
    }
}