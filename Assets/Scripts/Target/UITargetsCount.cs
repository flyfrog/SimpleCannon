using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using Zenject;

public class UITargetsCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _targetsDraw; 
    
    [Inject]
    private void Construct(TargetCountController targetCountControllerArg)
    {
        targetCountControllerArg.TargetsCountChangedEvent += DrawTimerText;
    }


    private void DrawTimerText(int currentTargetsCount, int startTargetsCount)
    {
        string stringTargets = new StringBuilder()
            .Append(currentTargetsCount)
            .Append("/")
            .Append(startTargetsCount)
            .ToString();
        
        _targetsDraw.text = stringTargets;
    }
}
