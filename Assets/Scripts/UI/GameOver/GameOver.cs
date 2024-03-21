using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.GameOver
{
    public class GameOver : MonoBehaviour
    {
        public void RestartHandler()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Time.timeScale = 1f;
        }

        public void ExitHandler()
        {
            SceneManager.LoadScene(0);
        }
    }
}
