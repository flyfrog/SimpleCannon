using UnityEngine;
using Zenject;

public class PoolBulletController : MonoBehaviour
{
    
    private const int POOL_COUNT = 20;
    private const bool _autoexpand = true;
    private Pool<Bullet> _pool;
    private Bullet _bulletPrefab; 

    [Inject]
    private void Construct(CannonFireSettingsSO cannonFireSettingsSOArg)
    {
        _bulletPrefab = cannonFireSettingsSOArg.bulletPrefab;
    }

    private void Awake()
    {
        InitPool();
    }

    private void InitPool()
    {
        _pool = new Pool<Bullet>(_bulletPrefab, POOL_COUNT, transform);
        _pool.autoExpand = _autoexpand;
    }


    public Bullet GetBullet()
    {
        return _pool.GetFreeElement();
    }
}