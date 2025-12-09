using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthManagement playerHealth;
    [SerializeField] private Image fullHealth;
    [SerializeField] private Image currentHealth;
    [SerializeField] private Store store;
   
    void Update()
    {
        fullHealth.fillAmount = playerHealth.MaxHealth / 5 ; // Initial ammount
        currentHealth.fillAmount = playerHealth.CurrentHealth / 5; // Updates the amount
    }
}
