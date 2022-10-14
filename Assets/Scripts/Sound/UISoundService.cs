using System;
using UnityEngine;
using Zenject;


[RequireComponent(typeof(AudioSource))]
public class UISoundService : StandartAudioService
{
    [SerializeField] private AudioClip _click;
    [SerializeField] private AudioClip _openPanel;

    [Inject]
    public void Construct(UIStart uiStartArg, UIMenu uiMenuArg, UIWin uiWinArg, UILoose uiLooseArg)
    {
        uiStartArg.OnClickOnStartGameButtonEvent += PlayOnClickSound;
        uiStartArg.PanelOpenedEvent += PlayOpenPanelSound;

        uiMenuArg.OnClickButtonOpenMenuEvent += PlayClickAndOpenPanel;
        uiMenuArg.OnClickButtonRestartGameEvent += PlayOnClickSound;
        uiMenuArg.OnClickButtonBackInGameEvent += PlayOpenPanelSound;

        uiWinArg.OpenedPanelEvent += PlayOpenPanelSound;
        uiLooseArg.OpenedPanelEvent += PlayOpenPanelSound;
    }

    private void PlayOnClickSound()
    {
        Play(_click);
    }

    private void PlayOpenPanelSound()
    {
        Play(_openPanel);
    }

    private void PlayClickAndOpenPanel()
    {
        PlayOpenPanelSound();
        PlayOnClickSound();
    }
}