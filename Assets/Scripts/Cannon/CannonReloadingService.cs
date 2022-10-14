using System;
using UnityEngine;
using Zenject;

public class CannonReloadingService:ITickable
{
    public event Action<float> RelodingStatusChangedEvent;  
    private float _currentTimeReload;
    private float _reloadTime;

    [Inject]
    public CannonReloadingService(CannonFireSettingsSO cannonFireSettingsSOArg)
    {
        _reloadTime = cannonFireSettingsSOArg.timeFireReload;
    }
    
    public void Tick()
    {
        Reloading();
        MathReloadStatus();
    }
 
    
    private void Reloading()
    {
        _currentTimeReload += Time.deltaTime;
    }

    public bool CanFire()
    {
        if (_currentTimeReload < _reloadTime)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Shot()
    {
        _currentTimeReload = 0f;
    }

    private void MathReloadStatus()
    {
        float timeReloadDelta = _currentTimeReload/_reloadTime;
        timeReloadDelta = Mathf.Clamp01(timeReloadDelta);
        RelodingStatusChangedEvent?.Invoke(timeReloadDelta);
    }
    
    
}