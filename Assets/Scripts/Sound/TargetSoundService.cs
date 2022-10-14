using UnityEngine;
using Zenject;


public class TargetSoundService : StandartAudioService
{
    [SerializeField] private AudioClip _targetExplosionClip;
    [SerializeField] private AudioClip _targetHitClip;
    [SerializeField] private AudioClip _targetDamageClip;


    [Inject]
    public void Construct(TargetDeathService targetDeathServiceArg, HitController hitControllerArg,
        TargetDamageController targetDamageControllerArg)
    {
        targetDamageControllerArg.TargetTookDamageEvent += PlayTargetDamage;
        hitControllerArg.TargetHitedEvent += PlayTargetHit;
        targetDeathServiceArg.TargetDeathEvent += PlayTargetExplosion;
    }

    private void PlayTargetExplosion(Target t)
    {
        PlayVariable(_targetExplosionClip);
    }

    private void PlayTargetHit()
    {
        PlayVariable(_targetHitClip);
    }

    private void PlayTargetDamage()
    {
        PlayVariable(_targetDamageClip);
    }
}