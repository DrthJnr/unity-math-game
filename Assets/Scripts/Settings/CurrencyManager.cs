using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CurrencyManager : MonoBehaviour
{
    // Singleton instance
    public static CurrencyManager instance;

    public int certificates = 100, healthLevel = 1, healthCost = 10;
    public int shieldLevel = 0, shieldCost = 20;

    private void Start()
    {
        GetStats();        
    }

    private void Update()
    {
        SaveStats();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SaveStats()
    {
        PlayerPrefs.SetInt("Certificados", certificates);
        PlayerPrefs.SetInt("NivelSaude", healthLevel);
        PlayerPrefs.SetInt("CustoSaude", healthCost);
        PlayerPrefs.SetInt("NivelEscudo", shieldLevel);
        PlayerPrefs.SetInt("CustoEscudo", shieldCost);
        PlayerPrefs.Save();        
    }

    private void GetStats()
    {
        certificates = PlayerPrefs.GetInt("Certificados", certificates);
        healthLevel = PlayerPrefs.GetInt("NivelSaude", healthLevel);        
        healthCost = PlayerPrefs.GetInt("CustoSaude", healthCost);
        shieldLevel = PlayerPrefs.GetInt("NivelEscudo", shieldLevel);
        shieldCost = PlayerPrefs.GetInt("CustoEscudo", shieldCost);
    }
}

