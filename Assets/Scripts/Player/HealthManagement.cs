using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class HealthManagement : MonoBehaviour
{    
    // instance it on Bootstrapper scene first, then use DontDestroyOnLoad to keep it through scenes
    // I'm learning about singletons, will refactor later
    public static HealthManagement instance;
    private GameObject canvas, gameOver;
    private string gameSceneName = "GameScene";  
    public float CurrentHealth { get; set; } = 3;
    public float MaxHealth { get; set; } = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnGameSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnGameSceneLoaded;
    }

    private void OnGameSceneLoaded(Scene scene, LoadSceneMode mode) // Called in Update to check if the game scene is loaded. NOT optimal, but works for now
    {
        if (scene.name == gameSceneName)
        {
            canvas = GameObject.Find("Canvas");
            gameOver = canvas.transform.Find("GameOverMenu").gameObject;
            if (gameOver == null)
            {
                Debug.LogWarning("Game Over Menu not found in the scene.");
            }
        }
    }

    private void Start() // Fix the logic
    {
        if(CurrencyManager.instance.healthLevel == 2)
        {
            CurrentHealth = 4;
            MaxHealth = 4;
        }
        else if (CurrencyManager.instance.healthLevel == 3)
        {
            CurrentHealth = 5;
            MaxHealth = 5;
        }
    }
    private void Update()
    {
        CheckIfAlive();
        if (CurrencyManager.instance.healthLevel == 1)
        {
            MaxHealth = 3;
        }
        else if (CurrencyManager.instance.healthLevel == 2)
        {
            MaxHealth = 4;
        }
        else if (CurrencyManager.instance.healthLevel == 3)
        {
            MaxHealth = 5;
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }
    void DestroyAllClones()
    {
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Answer");
        foreach (GameObject clone in clones)
        {
            Destroy(clone);
        }
    }

    private void CheckIfAlive()
    {
        if (gameOver != null)
        {
            if (CurrentHealth <= 0)
            {
                DestroyAllClones();
                gameOver.SetActive(true);            
                GameControl.isGameOver = 1;
                GameControl.isPaused = 1;
                if (GameControl.updateCertificates == 1)
                {
                    CurrencyManager.instance.certificates += GameControl.score / 5;
                    GameControl.updateCertificates = 0;
                }
            }
            else 
            {
                gameOver.SetActive(false);
                GameControl.updateCertificates = 1;                    
            }
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
