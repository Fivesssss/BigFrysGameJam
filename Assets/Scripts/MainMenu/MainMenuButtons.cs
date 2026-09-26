using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
    public void LoadMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadHelp() 
    {
        SceneManager.LoadScene("Help Menu");
    }
}
