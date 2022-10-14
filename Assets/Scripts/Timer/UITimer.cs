using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class UITimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerDraw; 
    
    [Inject]
    private void Construct(TimerController timerServiceArg)
    {
        timerServiceArg.TimeChangedEvent += DrawTimerText;
    }


    private void DrawTimerText(int time)
    {
        string timeText = time.ToString();
        _timerDraw.text = timeText;
    }
}
