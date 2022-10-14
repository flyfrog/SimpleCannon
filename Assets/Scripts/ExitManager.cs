using UnityEngine;

public class ExitManager
{
    public ExitManager(UIMenu uiMenu, UIStart uiStartArg)
    {
        uiMenu.OnClickButtonExitGameEvent += Exit;
        uiStartArg.OnClickButtonExitGameEvent += Exit;
    }

    private void Exit()
    {
        Application.Quit();
    }
}