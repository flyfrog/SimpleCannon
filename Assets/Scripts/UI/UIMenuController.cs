using Zenject;

public class UIMenuController
{
    private PauseManager _pauseManager;
    private UIMenu _uiMenu;

    [Inject]
    public UIMenuController(UIMenu uiMenuArg, PauseManager pauseManagerArg)
    {
        _pauseManager = pauseManagerArg;
        _uiMenu = uiMenuArg;
        
        _uiMenu.OnClickButtonOpenMenuEvent += OpenMenu;
        _uiMenu.OnClickButtonBackInGameEvent += Closemenu;
    }

    private void OpenMenu()
    {
        _uiMenu.ShowPanel();
        _pauseManager.PauseOn();
    }
    
    private void Closemenu()
    {
        _uiMenu.HidePanel();
        _pauseManager.PauseOff();
    }
    
 
}