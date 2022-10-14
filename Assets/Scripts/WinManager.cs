using Zenject;

public class WinManager  
{
    private PauseManager _pauseManager;
    private UIWin _UIWin;


    [Inject]
    public WinManager(PauseManager pauseManagerArg,  UIWin uiWinArg, TargetCountController targetCountControllerArg)
    {
        _pauseManager = pauseManagerArg;
        targetCountControllerArg.AllTargetsDestroyed += Win;
        _UIWin = uiWinArg;
    }

    private void Win()
    {
        _pauseManager.PauseOn();
        _UIWin.ShowPanel();
    }
}