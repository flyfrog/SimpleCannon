using UnityEngine;
using Zenject;


public class GameOverManager
{
    private PauseManager _pauseManager;
    private UILoose _UILoose;

    [Inject]
    public GameOverManager(PauseManager pauseManagerArg, TimerController timerControllerArg, UILoose uiLooseArg)
    {
        _pauseManager = pauseManagerArg;
        timerControllerArg.TimeEndEvent += TimeLoose;
        _UILoose = uiLooseArg;
    }

    private void TimeLoose()
    {
        _pauseManager.PauseOn();
        _UILoose.ShowPanel();
    }
}