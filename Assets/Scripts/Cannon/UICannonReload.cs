using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UICannonReload : MonoBehaviour
{
    [SerializeField] private Image _statusImage;
    private float _lastReloadStatusValue;

    [Inject]
    private void Construct(CannonReloadingService cannonReloadingServiceArg)
    {
        cannonReloadingServiceArg.RelodingStatusChangedEvent += RedrawReloadStatus;
    }

    private void RedrawReloadStatus(float value)
    {
        if (_lastReloadStatusValue != value)
        {
            _statusImage.fillAmount = value;
            _lastReloadStatusValue = value;
        }
    }
}