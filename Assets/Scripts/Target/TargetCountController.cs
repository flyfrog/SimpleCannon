using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TargetCountController : MonoBehaviour
{
    public event Action AllTargetsDestroyed;
    public event Action<int, int> TargetsCountChangedEvent;

    private int _startCountsTargets;
    private List<Target> _targetsList = new List<Target>();

    [Inject]
    public void Construct(TargetDeathService targetDeathService)
    {
        targetDeathService.TargetDeathEvent += TargetDeath;
    }

    private void TargetDeath(Target target)
    {
        _targetsList.Remove(target);
        UpdateTargetsCount();
        CheckForTargetsForWin();
    }

    private void CheckForTargetsForWin()
    {
        if (GetCurrentTargetsCounts() == 0)
            AllTargetsDestroyed?.Invoke();
    }

    private void UpdateTargetsCount()
    {
        TargetsCountChangedEvent?.Invoke(GetCurrentTargetsCounts(), _startCountsTargets);
    }

    public void RegistrationTarget(Target target)
    {
        _targetsList.Add(target);
        MathMaxTargetsCounts();
        UpdateTargetsCount();
    }

    private void MathMaxTargetsCounts()
    {
        int countTargets = _targetsList.Count;
        if (_startCountsTargets < countTargets)
            _startCountsTargets = countTargets;
    }

    private int GetCurrentTargetsCounts()
    {
        return _targetsList.Count;
    }
}