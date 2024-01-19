using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame() //sets play game to load the first level
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame() //sets quit to quit the application
    {
        Application.Quit();
    }

    public void Menu() //sets menu to take you to the main menu
    {
        SceneManager.LoadScene("MainMenu");
    }
}
