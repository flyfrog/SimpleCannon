using System;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public event Action<Bullet, Target> TargetHitDamageObjectEvent;
    public event Action<Bullet, GameObject> BulletHitedEvent;
    public event Action  TargetHitedEvent;

    public void BulletHit(Bullet bullet, GameObject victimObj)
    {
        BulletHitedEvent?.Invoke(bullet, victimObj);
        
        Target target = victimObj.GetComponent<Target>();
        if (target)
        {
            TargetHitDamageObjectEvent?.Invoke(bullet, target);
        }
    }

    public void TargetHit(Target target)
    {
        TargetHitedEvent?.Invoke();
    }
}