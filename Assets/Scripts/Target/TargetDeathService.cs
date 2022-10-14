using System;
using UnityEngine;
using Zenject;

public class TargetDeathService
{

    public event Action<Target> TargetDeathEvent; 
    private TargetDamageController _targetDamageController;
    

    [Inject]
    public TargetDeathService(TargetDamageController targetDamageControllerArg)
    {
        _targetDamageController = targetDamageControllerArg;
        Subscribe();
    }
    private void Subscribe()
    {
        _targetDamageController.TargetExplodedEvent += BlowUpTarget;
    }

    private void BlowUpTarget(Target target)
    {
        TargetDeathEvent?.Invoke(target);
        GameObject.Destroy(target.gameObject);
    }
    
}