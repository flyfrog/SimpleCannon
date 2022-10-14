using UnityEngine;
using Zenject;

public class BulletExplosionFXController
{
    private ParticleSystem _bulletExplosion;
    private BulletDeathService _bulletDeathService;

    [Inject]
    public BulletExplosionFXController(FXSettingsSO fxSettingsSoArg, BulletDeathService bulletDeathServiceArg)
    {
        _bulletExplosion = fxSettingsSoArg.bulletExplosion;
        _bulletDeathService = bulletDeathServiceArg;
        Subscribe();
    }

    private void Subscribe()
    {
        _bulletDeathService.BulletDeathEvent += BulletExposionFX;
    }

    private void BulletExposionFX(Bullet bulletArg)
    {
        Vector3 fxPosition = bulletArg.gameObject.transform.position;
        GameObject.Instantiate(_bulletExplosion.gameObject, fxPosition, Quaternion.identity);
    }
}