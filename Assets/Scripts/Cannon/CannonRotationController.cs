using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Zenject;

public class CannonRotationController : ITickable
{
    private Cannon _cannon;
    private InputService _inputService;
    private float _maxRotationAngle = 90f;
    private PauseManager _pauseManager;

    [Inject]
    public CannonRotationController(InputService inputServiceArg, Cannon cannonArg, PauseManager pauseManagerArg)
    {
        _pauseManager = pauseManagerArg;
        _cannon = cannonArg;
        _inputService = inputServiceArg;
    }


    public void Tick()
    {
        if(_pauseManager.GetPauseState())
            return;
        
        RotateCannon();
    }

    private void RotateCannon()
    {
        Vector3 mousePosition = _inputService.GetMousePosition();
        Vector3 gunPosition = _cannon.GetGunPosition();
        Vector3 shiftVector = mousePosition - gunPosition; // сдвиг из за того что пушка не в  0 0 0 координатах 
        Quaternion rotationAngle = Quaternion.LookRotation(Vector3.forward, shiftVector);
        
        float cannonZAngle = rotationAngle.eulerAngles.z;
        
        if(!CheckNewRotationValueInAngleLimit(cannonZAngle))
            return;
        
        _cannon.SetCannonRotation(rotationAngle);
    }

    private bool CheckNewRotationValueInAngleLimit(float angleArg)
    {
        if (angleArg > 0 && angleArg < _maxRotationAngle || angleArg < 360 && angleArg > 360 - _maxRotationAngle)
            return true; // yes in limit 
        
        return false; 
    }
}