using System;
using UnityEngine;
using Zenject;

public class InputService : ITickable
{

    public event Action OnClickEvent;

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    private void OnClick()
    {
        OnClickEvent?.Invoke();
    }

    public Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
}