using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Store : MonoBehaviour
{    
    public float health = 0.6f;
    public HealthManagement healthManagement;
    public TextMeshProUGUI certifText, healthlvlText, healthCostText;
    public CurrencyManager currencyManager;    

    // Start is called before the first frame update
    void Start()
    {                
        certifText.text = $"Certificados : {CurrencyManager.instance.certificates.ToString()}";
        healthlvlText.text = "Nível " + CurrencyManager.instance.healthLevel.ToString();
        healthCostText.text = "" + CurrencyManager.instance.healthCost.ToString();
        if (healthManagement.MaxHealth == 3)
        {
            health = 0.6f;
        }
        else if(healthManagement.MaxHealth == 4)
        {
            health = 0.8f;
        }
        else
        {
            health = 1f;
        }
    }

    public void BuyHealth()
    {
        if (CurrencyManager.instance.healthLevel == 1 && CurrencyManager.instance.certificates >= CurrencyManager.instance.healthCost)
        {         
            health = 0.8f;
            CurrencyManager.instance.healthCost = 30;
            CurrencyManager.instance.healthLevel = 2;
            CurrencyManager.instance.certificates -= 10;
            healthlvlText.text = "Nível " + CurrencyManager.instance.healthLevel.ToString();
            certifText.text = "Certificados : " + CurrencyManager.instance.certificates.ToString();
            healthCostText.text = "" + CurrencyManager.instance.healthCost.ToString();
        }
        else if (CurrencyManager.instance.healthLevel == 2 && CurrencyManager.instance.certificates >= CurrencyManager.instance.healthCost)
        {            
            health = 1f;
            CurrencyManager.instance.healthLevel = 3;
            CurrencyManager.instance.certificates -= 30;
            healthlvlText.text = "Nível " + CurrencyManager.instance.healthLevel.ToString();
            certifText.text = "Certificados : " + CurrencyManager.instance.certificates.ToString();
            healthCostText.text = "MAX";
        }
    }
}
