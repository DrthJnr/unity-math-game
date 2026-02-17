using UnityEngine;

public class LoadMenuScene : MonoBehaviour
{
    [SerializeField] private string MenuSceneName;

    void Awake()
    {
        LoadMenu();
    }
    void LoadMenu()
    {
        if (MenuSceneName != "")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(MenuSceneName);
        }
        else 
        {
            Debug.LogWarning("Menu scene name is not set.");
        }
    }
}
