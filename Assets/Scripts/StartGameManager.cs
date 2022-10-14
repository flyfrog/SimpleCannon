using Zenject;

public class StartGameManager
{
    private PauseManager _pauseManager;
    private UIStart _uiStart;
    private TimerController _timerController;
    
    [Inject]
    public StartGameManager(UIStart uiStartArg, PauseManager PauseManagerArg, TimerController timerControllerArg)
    {
        _pauseManager = PauseManagerArg;
        _uiStart = uiStartArg;
        _uiStart.OnClickOnStartGameButtonEvent += StartGame;
        _timerController = timerControllerArg; 
    }

    private void StartGame()
    {
        UnpauseGame();
        CloseStartUIPanel();
        _timerController.StartTimer();
    }

    private void CloseStartUIPanel()
    {
        _uiStart.HidePanel();
    }

    private void UnpauseGame()
    {
        _pauseManager.PauseOff();
    }
}