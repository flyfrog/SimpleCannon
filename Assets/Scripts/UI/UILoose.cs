using System;
using UnityEngine;
using UnityEngine.UI;

public class UILoose : MonoBehaviour
{
    [SerializeField] private Transform _loosePanelContainer;
    [SerializeField] private Button _restartButton;
    public event Action onClickRestartGameButtonEvent;
    public event Action OpenedPanelEvent;

    private void Start()
    {
        _restartButton.onClick.AddListener(OnClickRestartGame);
    }

    private void OnClickRestartGame()
    {
        onClickRestartGameButtonEvent?.Invoke();
    }

    public void ShowPanel()
    {
        OpenedPanelEvent?.Invoke();
        _loosePanelContainer.gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        _loosePanelContainer.gameObject.SetActive(false);
    }
}