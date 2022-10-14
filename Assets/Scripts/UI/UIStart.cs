using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStart : MonoBehaviour
{
    [SerializeField] private Transform _startUIPanel;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitGameButton;

    public event Action OnClickOnStartGameButtonEvent;
    public event Action PanelOpenedEvent;
    public event Action OnClickButtonExitGameEvent;

    private void Start()
    {
        _startButton.onClick.AddListener(OnClickRestartGame);
        _exitGameButton.onClick.AddListener(OnClickExitGame);
    }

    private void OnClickRestartGame()
    {
        OnClickOnStartGameButtonEvent?.Invoke();
    }


    public void ShowPanel()
    {
        PanelOpenedEvent?.Invoke();
        _startUIPanel.gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        _startUIPanel.gameObject.SetActive(false);
    }
    
    private void OnClickExitGame()
    {
        OnClickButtonExitGameEvent?.Invoke();
    }
}