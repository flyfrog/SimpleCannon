using UnityEngine.SceneManagement;
using Zenject;

public class RestartManager
    {

        [Inject]
        public RestartManager(UIMenu uiMenuArg, UIWin uiWinArg, UILoose uiLooseArg)
        {
            uiMenuArg.OnClickButtonRestartGameEvent+= RestartGame;
            uiWinArg.onClickRestartGameButtonEvent += RestartGame;
            uiLooseArg.onClickRestartGameButtonEvent += RestartGame;
        }
            
        
        
        private void RestartGame()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
 