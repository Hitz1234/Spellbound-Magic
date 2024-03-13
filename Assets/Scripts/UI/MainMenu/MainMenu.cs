using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Animator mainMenuLeftAnimation;

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
        mainMenuLeftAnimation.SetTrigger("optionBtn");
    }
}
