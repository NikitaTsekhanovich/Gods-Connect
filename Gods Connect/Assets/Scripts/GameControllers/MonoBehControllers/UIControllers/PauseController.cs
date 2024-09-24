using MainMenu;
using UnityEngine;

namespace GameControllers.MonoBehControllers.UIControllers
{
    public class PauseController : Screen
    {
        public bool GameIsPaused { get; private set; }

        public void PauseGame()
        {
            GameIsPaused = true;
            Time.timeScale = 0f;
        }

        public void ContinueGame()
        {
            GameIsPaused = false;
            Time.timeScale = 1f;
        }

        public void ExitGame()
        {
            Time.timeScale = 1f;
            LoadingScreenController.Instance.ChangeScene("Store");
            GameIsPaused = false;
        }
    }
}
