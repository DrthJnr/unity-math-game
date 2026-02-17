using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.InputSystem;

// Refactor EVERYTHING to other scripts

public class ButtonsFunctions : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    void Update()
    {
        if (pauseMenu != null && GameControl.isPaused == 0)
        {
            pauseMenu.SetActive(false);
        } else if (pauseMenu != null && GameControl.isPaused == 1)
        {
            pauseMenu.SetActive(true);
        }
        if (gameOverMenu != null && GameControl.isGameOver == 0)
        {
            gameOverMenu.SetActive(false);
        } else if (gameOverMenu != null && GameControl.isGameOver == 1)
        {
            gameOverMenu.SetActive(true);
        }
    }

    public static void EnterMenu()
    {        
        switch (GameControl.difficulty)
        {
            case 0:
                GameControl.easyHScore = GameControl.score;
                break;
            case 1:
                GameControl.mediumHScore = GameControl.score;
                break;
            case 2:
                GameControl.hardHScore = GameControl.score;
                break;
        }

        SceneManager.LoadScene("Menu");
        ResumeGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        GameControl.isPaused = 1;
        Debug.Log(Time.timeScale);
    }
    static void ResumeGame()
    {
        GameControl.isPaused = 0;
    }

    public void ResumeGameButton()
    {
        ResumeGame();
    }

    public void OpenStoreButton()
    {
        MenuButtons.OpenStore();
    }
}