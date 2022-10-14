using System;
using Zenject;

public class TargetDamageController
{
    private HitController _hitController;
    public Action<Target> TargetExplodedEvent; 
    public Action TargetTookDamageEvent; 

    [Inject]
    public TargetDamageController(HitController hitControllerArg)
    {
        _hitController = hitControllerArg;
        Subscribe(); 
    }

    private void Subscribe()
    {
        _hitController.TargetHitDamageObjectEvent += MakeDamage;
    }

    private void MakeDamage(Bullet bullet, Target target)
    {
        TargetTookDamageEvent?.Invoke();
         target.TakeDamage(bullet.GetDamage());
         CheckTargetHealth(target);
    }

    private void CheckTargetHealth(Target target)
    {
        if (target.GetHealth() <= 0)
        {
            TargetExplodedEvent?.Invoke(target);
        }
    }
}