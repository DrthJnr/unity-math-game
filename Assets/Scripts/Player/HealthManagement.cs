using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManagement : MonoBehaviour
{    
    [SerializeField] private GameObject pause, gameOver, player;    
    public float CurrentHealth { get; set; } = 3;
    public float MaxHealth { get; set; } = 3;

    private void Start()
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
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            DestroyAllClones();
            gameOver.SetActive(true);            
            GameControl.stopGame = 1;
        }
        else 
        {
            gameOver.SetActive(false);                        
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
}
