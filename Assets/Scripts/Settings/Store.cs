using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Store : MonoBehaviour
{    
    // Finish health upgrade levels and shield upgrade levels
    public float health = 0.6f;
    public TextMeshProUGUI certifText, healthlvlText, healthCostText;
    public TextMeshProUGUI shieldlvlText, shieldCostText;
    public Button healthButton, shieldButton;

    // Start is called before the first frame update
    void Start()
    {                
        UpdateStoreGUI();
    }
    void Update()
    {
        if (HealthManagement.instance.MaxHealth == 3)
        {
            health = 0.6f;
        }
        else if(HealthManagement.instance.MaxHealth == 4)
        {
            health = 0.8f;
        }
        else
        {
            health = 1f;
        }
    }

    public void UpgradeHealth()
    {
        if (CurrencyManager.instance.healthLevel == 1 && CurrencyManager.instance.certificates >= CurrencyManager.instance.healthCost)
        {         
            health = 0.8f;
            CurrencyManager.instance.healthCost = 30;
            CurrencyManager.instance.healthLevel = 2;
            CurrencyManager.instance.certificates -= CurrencyManager.instance.healthCost;
            UpdateStoreGUI();
        }
        else if (CurrencyManager.instance.healthLevel == 2 && CurrencyManager.instance.certificates >= CurrencyManager.instance.healthCost)
        {            
            health = 1f;
            CurrencyManager.instance.healthLevel = 3;
            CurrencyManager.instance.healthCost *= 3;
            CurrencyManager.instance.certificates -= CurrencyManager.instance.healthCost; 
            UpdateStoreGUI();
        }
    }

    public void UpgradeShield()
    {
        // Shield upgrade logic here
        if (CurrencyManager.instance.shieldLevel == 0 && CurrencyManager.instance.certificates >= CurrencyManager.instance.shieldCost)
        {         
            CurrencyManager.instance.shieldLevel = 1;
            CurrencyManager.instance.certificates -= CurrencyManager.instance.shieldCost;
            UpdateStoreGUI();
        }
        else if (CurrencyManager.instance.shieldLevel == 1 && CurrencyManager.instance.certificates >= CurrencyManager.instance.shieldCost)
        {            
            CurrencyManager.instance.shieldLevel = 2;
            CurrencyManager.instance.shieldCost *= 3;
            CurrencyManager.instance.certificates -= CurrencyManager.instance.shieldCost;
            UpdateStoreGUI();
        }
    }
    public void UpdateStoreGUI() // Fix the GUI shield update logic
    {
        certifText.text = $"Certificados : {CurrencyManager.instance.certificates}";

        // Health GUI update logic
        
        healthlvlText.text = "Nivel " + CurrencyManager.instance.healthLevel.ToString();
        if (CurrencyManager.instance.healthLevel != 3)
        {
            healthCostText.text = "" + CurrencyManager.instance.healthCost.ToString();
        }
        else
        {
            healthButton.GetComponentInChildren<TextMeshProUGUI>().SetText("MAXIMO");
            healthButton.interactable = false;
            healthCostText.text = "MAX";
        }

        // Shield GUI update logic

        if (CurrencyManager.instance.shieldLevel == 1)
        {
            shieldlvlText.text = "Nivel " + CurrencyManager.instance.shieldLevel.ToString();
            shieldCostText.text = "" + CurrencyManager.instance.shieldCost.ToString();
            shieldButton.GetComponentInChildren<TextMeshProUGUI>().SetText("MELHORAR");
        }
        else if (CurrencyManager.instance.shieldLevel == 2)
        {
            shieldButton.GetComponentInChildren<TextMeshProUGUI>().SetText("MAXIMO");
            shieldButton.interactable = false;
            shieldCostText.text = "MAX";
            shieldlvlText.text = "Nivel " + CurrencyManager.instance.shieldLevel.ToString();
        }
        else
        {
            shieldButton.GetComponentInChildren<TextMeshProUGUI>().SetText("COMPRAR");
            shieldCostText.text = "" + CurrencyManager.instance.shieldCost.ToString();            
            shieldlvlText.text = "Bloqueado";
        }
    }
}
