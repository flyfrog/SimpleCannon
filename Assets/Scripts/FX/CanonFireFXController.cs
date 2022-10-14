using UnityEngine;
using Zenject;

public class CanonFireFXController
{
    private ParticleSystem _fireSmogPrefab;
    private ParticleSystem _fireSparksPrefab;
    private CannonShotController _cannonShotController;
    private BulletSpawner _bulletSpawner;
    
    [Inject]
    public CanonFireFXController(FXSettingsSO fxSettingsSoArg, CannonShotController cannonShotControllerArg,BulletSpawner bulletSpawnerArg)
    {
        _fireSmogPrefab = fxSettingsSoArg.cannonFireSmog;
        _fireSparksPrefab = fxSettingsSoArg.cannonFireSparks;
        _cannonShotController = cannonShotControllerArg;
        _bulletSpawner = bulletSpawnerArg;

        Subscribe();
    }

    private void Subscribe()
    {
        _cannonShotController.FiredEvent += FireFX;
    }

    private void FireFX()
    {
        SpawnFX(_fireSmogPrefab.gameObject);
        SpawnFX(_fireSparksPrefab.gameObject);
    }

    private void SpawnFX(GameObject fxPrefab)
    {
        GameObject.Instantiate(fxPrefab, _bulletSpawner.GetSpawnerPoint(), _bulletSpawner.GetSpawnerTransform().rotation);
    }
    
    
}