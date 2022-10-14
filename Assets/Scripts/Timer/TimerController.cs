using System;
using UnityEngine;
using Zenject;

public class TimerController : ITickable, IInitializable
{
    public Action TimeEndEvent;
    public Action<int> TimeChangedEvent;
    
    private int _lastCeilTime;
    private float _currentGameTime;
    private float _startGameTime;
    private PauseManager _pauseManager;
    private bool _timerRuningStatus; 
    
    [Inject]
    public TimerController(GameSettingsSO gameSettingsSoArg, PauseManager pauseManagerArg)
    {
        _pauseManager = pauseManagerArg;
        SetSettings(gameSettingsSoArg);
    }

    private void SetSettings(GameSettingsSO gameSettingsSoArg)
    {
        _startGameTime = gameSettingsSoArg.startTime;
        
    }

    public void Tick()
    {
        if (_pauseManager.GetPauseState())
            return;
        
        if(!_timerRuningStatus)
            return;

        TimerDecriment();
        CheckRemainingTime();
        CheckTimeForDrawUpdate();
    }

    private void CheckTimeForDrawUpdate()
    {
        int ceilTime = Mathf.FloorToInt(_currentGameTime); 
        
        if(ceilTime==_lastCeilTime)
            return;
        
        _lastCeilTime = ceilTime;

        ceilTime = Math.Clamp(ceilTime, 0, int.MaxValue);
        TimeChangedEvent?.Invoke(ceilTime);
    }

    private void TimerDecriment()
    {
        _currentGameTime -= Time.deltaTime;
    }


    private void PrepareTimer()
    {
        _currentGameTime = _startGameTime;
        CheckTimeForDrawUpdate();
    }

    public void StartTimer()
    {
        PrepareTimer();
        _timerRuningStatus = true;
    }

    private void CheckRemainingTime()
    {
        if (_currentGameTime <= 0f)
        {
            _timerRuningStatus = false;
            TimeEndEvent?.Invoke();
        }
    }

    public void Initialize()
    {
        PrepareTimer();
    }
}