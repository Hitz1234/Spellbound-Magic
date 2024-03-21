using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private Animator mainMenuLeftAnimation;
        private static readonly int OptionBtn = Animator.StringToHash("optionBtn");

        public void StartHandler()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }

        public void ExitHandler()
        {
            Application.Quit();
        }

        public void OptionHandler()
        {
            mainMenuLeftAnimation.SetTrigger(OptionBtn);
        }
    }
}
