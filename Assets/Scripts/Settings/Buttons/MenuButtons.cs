using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject playMenu;
    public GameObject infoMenu;
    public void EasyGame()
    {        
        SetDifficulty(0);
        StartGame();
    }
    public void NormalGame()
    {        
        SetDifficulty(1);
        StartGame();
    }
    public void HardGame()
    {        
        SetDifficulty(2);
        StartGame();
    }

    public void StartGame()
    {
        GameControl.isPaused = 0;
        GameControl.isGameOver = 0;
        SceneManager.LoadScene("GameScene");
        HealthManagement.instance.ResetHealth();
    }

    void SetDifficulty(int difficulty)
    {
        GameControl.difficulty = difficulty;
        GameControl.score = 0;        
        SceneManager.LoadScene("GameScene");
    }

    public void OpenPlayMenu()
    {
        if (playMenu != null)
        {
            playMenu.SetActive(true);
        }
    }
    public void ClosePlayMenu()
    {
        if (playMenu != null)
        {
            playMenu.SetActive(false);
        }
    }

    public void OpenInfoMenu()
    {
        if (infoMenu != null)
        {
            infoMenu.SetActive(true);
        }
    }
    public void CloseInfoMenu()
    {
        if (infoMenu != null)
        {
            infoMenu.SetActive(false);
        }
    }

    public static void OpenStore()
    {
        SceneManager.LoadScene("Store");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
