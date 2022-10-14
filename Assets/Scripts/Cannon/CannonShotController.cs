using System;
using UnityEngine;
using Zenject;

public class CannonShotController
{
    public event Action FiredEvent;

    private float _fireForce;
    private InputService _inputService;
    private BulletSpawner _bulletSpawner;
    private PoolBulletController _poolBulletController;
    private PauseManager _pauseManager;
    private CannonReloadingService _cannonReloadingService;

    [Inject]
    public CannonShotController(InputService inputServiceArg, BulletSpawner bulletSpawnerArg,
        CannonFireSettingsSO cannonFireSettingsSOArg, PoolBulletController poolBulletControllerArg,
        PauseManager pauseManagerArg, CannonReloadingService cannonReloadingServiceArg)
    {
        _bulletSpawner = bulletSpawnerArg;
        _inputService = inputServiceArg;
        _poolBulletController = poolBulletControllerArg;
        _pauseManager = pauseManagerArg;
        _cannonReloadingService = cannonReloadingServiceArg;
        Subscribe();
        SetSettings(cannonFireSettingsSOArg);
    }

    private void SetSettings(CannonFireSettingsSO cannonFireSettingsSoArg)
    {
        _fireForce = cannonFireSettingsSoArg.fireForce;
    }

    private void Subscribe()
    {
        _inputService.OnClickEvent += Shot;
    }


    private void Shot()
    {
        if (_pauseManager.GetPauseState())
            return;

        if (!_cannonReloadingService.CanFire())
            return;

        FiredEvent?.Invoke();
        Bullet bulletForFire = _poolBulletController.GetBullet();
        SetBulletInStartPosition(bulletForFire);
        SetPhysicForceForBullet(bulletForFire);
        _cannonReloadingService.Shot();
    }


    private void SetPhysicForceForBullet(Bullet bulletForFire)
    {
        bulletForFire.GetComponent<Rigidbody2D>().velocity = _bulletSpawner.GetSpawnerTransform().up * _fireForce;
    }

    private void SetBulletInStartPosition(Bullet bulletForFire)
    {
        bulletForFire.transform.position = _bulletSpawner.GetSpawnerPoint();
    }
}