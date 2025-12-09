using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SocialPlatforms.Impl;

public class ButtonsFunctions : MonoBehaviour
{
    [SerializeField] private string Menu;    
    [SerializeField] private string GameScene;
    [SerializeField] private string Store;
    [SerializeField] private GameObject PlaySettings;
    [SerializeField] private GameObject GameSettings;
    [SerializeField] private GameObject Bullet;
    public UnityEngine.UI.Button delayButton;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    private bool canBePressed = true;
    [SerializeField] private float waitTime = 1.5f;

    public void EnterMenu()
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

        SceneManager.LoadScene(Menu);
        ResumeGame();
    }

    public void EasyGame()
    {        
        GameControl.difficulty = 0;
        GameControl.score = 0;
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(false);
        }
        Debug.Log("Difficulty : " + GameControl.difficulty);
        SceneManager.LoadScene(GameScene);
        ResumeGame();
    }
    public void NormalGame()
    {        
        GameControl.difficulty = 1;
        GameControl.score = 0;
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(false);
        }
        Debug.Log("Difficulty : " + GameControl.difficulty);
        SceneManager.LoadScene(GameScene);
        ResumeGame();
    }
    public void HardGame()
    {        
        GameControl.difficulty = 2;
        GameControl.score = 0;
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(false);
        }
        Debug.Log("Difficulty : " + GameControl.difficulty);
        SceneManager.LoadScene(GameScene);
        ResumeGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenGSettings()
    {
        GameSettings.SetActive(true);
    }

    public void OpenPSettings()
    {
        PlaySettings.SetActive(true);
    }

    public void CloseSettings()
    {
        GameSettings.SetActive(false);
        PlaySettings.SetActive(false);
    }

    public void Shoot()
    {
        if (canBePressed)
        {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            StartCoroutine(DelayButton());
        }

    }

    private IEnumerator DelayButton()
    {
        canBePressed = false;
        delayButton.interactable = false;
        yield return new WaitForSeconds(waitTime);
        delayButton.interactable = true;
        canBePressed = true;
    }



    public void PauseGame()
    {
        GameControl.stopGame = 1;
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
        Debug.Log(Time.timeScale);
    }
    public void ResumeGame()
    {
        GameControl.stopGame = 0;
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        Debug.Log(Time.timeScale);
    }
    public void OpenStore()
    {
        SceneManager.LoadScene(Store);
    }
}
public static class GameControl
{
    // easy = 0 medium = 1 hard = 2
    // stopGame 0 = run 1 = pause
    // newQuestion 0 = no 1 = generate new question
    // score = player score

    public static int difficulty, stopGame, newQuestion, score, easyHScore, mediumHScore, hardHScore;
}