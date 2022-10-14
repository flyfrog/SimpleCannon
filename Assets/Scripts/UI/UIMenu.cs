using System;
using UnityEngine;
using UnityEngine.UI;


public class UIMenu : MonoBehaviour
{
    [SerializeField] private Transform _menuPanelContainer;
    [SerializeField] private Button _returnInGameButton;
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private Button _openMenuButton;
    [SerializeField] private Button _exitGameButton;

    public event Action OnClickButtonBackInGameEvent;
    public event Action OnClickButtonRestartGameEvent;
    public event Action OnClickButtonOpenMenuEvent;
    public event Action OnClickButtonExitGameEvent;

    private void Start()
    {
        _restartGameButton.onClick.AddListener(OnClickRestartGame);
        _returnInGameButton.onClick.AddListener(OnClickReturnInGame);
        _openMenuButton.onClick.AddListener(OnClickOpenMenu);
        _exitGameButton.onClick.AddListener(OnClickExitGame);
    }

    private void OnClickOpenMenu()
    {
        OnClickButtonOpenMenuEvent?.Invoke();
    }

    private void OnClickRestartGame()
    {
        OnClickButtonRestartGameEvent?.Invoke();
    }


    private void OnClickReturnInGame()
    {
        OnClickButtonBackInGameEvent?.Invoke();
    }

    private void OnClickExitGame()
    {
        OnClickButtonExitGameEvent?.Invoke();
    }


    public void ShowPanel()
    {
        _menuPanelContainer.gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        _menuPanelContainer.gameObject.SetActive(false);
    }
}