using UnityEngine;
using Zenject;

public class BulletSoundService : StandartAudioService 
{
    [SerializeField] private AudioClip _bulletExplosionClip;


    [Inject]
    public void Construct(BulletDeathService bulletDeathServiceArg)
    {
        bulletDeathServiceArg.BulletDeathEvent += PlayBulletExplosion;
    }

    private void PlayBulletExplosion(Bullet obj)
    {
        PlayVariable(_bulletExplosionClip);
    }
    
    
}