using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;

    public int certificates = 0, healthLevel = 1, healthCost = 10;

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
        PlayerPrefs.Save();        
    }

    private void GetStats()
    {
        certificates = PlayerPrefs.GetInt("Certificados", certificates);
        healthLevel = PlayerPrefs.GetInt("NivelSaude", healthLevel);        
        healthCost = PlayerPrefs.GetInt("CustoSaude", healthCost);
    }
}

