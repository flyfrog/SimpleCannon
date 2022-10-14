using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AimMoverService : MonoBehaviour
{
    [SerializeField] private Transform _aimImage;
    private PauseManager _pauseManager;
    
    [Inject]
    private void Construct(PauseManager pauseManagerArg)
    {
        _pauseManager = pauseManagerArg;
    }

    void Update()
    {
        if(_pauseManager.GetPauseState())
            return;
        
        MoveAim();
    }

    private void MoveAim()
    {
        _aimImage.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}