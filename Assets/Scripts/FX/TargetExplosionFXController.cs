using UnityEngine;
using Zenject;

public class TargetExplosionFXController
{
    private ParticleSystem _targetExplosionPrefab;
    private TargetDeathService _targetDeathServiceArg;

    [Inject]
    public TargetExplosionFXController(FXSettingsSO fxSettingsSoArg, TargetDeathService targetDeathServiceArg)
    {
        _targetExplosionPrefab = fxSettingsSoArg.targetExplosion;
        _targetDeathServiceArg = targetDeathServiceArg;
        Subscribe();
    }

    private void Subscribe()
    {
        _targetDeathServiceArg.TargetDeathEvent += TargetExposionFX;
    }

    private void TargetExposionFX(Target targetArg)
    {
        Vector3 fxPosition = targetArg.gameObject.transform.position;
        GameObject.Instantiate(_targetExplosionPrefab.gameObject, fxPosition, Quaternion.identity);
    }
}