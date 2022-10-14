using System;
using UnityEngine;
using Zenject;

public class BulletDeathService
{

    public event Action<Bullet> BulletDeathEvent;  
    private HitController _hitController;
 

    [Inject]
    public BulletDeathService(HitController hitControllerArg)
    {
        _hitController = hitControllerArg;
        Subscribe();
    }
    private void Subscribe()
    {
        _hitController.BulletHitedEvent += BlowUpBullet;
    }

    private void BlowUpBullet(Bullet bullet, GameObject arg2)
    {
        BulletDeathEvent?.Invoke(bullet);
        DeactivateBullet(bullet);
    }

    private static void DeactivateBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}