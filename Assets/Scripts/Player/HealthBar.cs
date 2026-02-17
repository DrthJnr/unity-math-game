using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fullHealth;
    [SerializeField] private Image currentHealth;
    [SerializeField] private Store store;

    void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        fullHealth.fillAmount = HealthManagement.instance.MaxHealth / 5 ; // Initial max health is 3, upgraded max health is 4 or 5
        currentHealth.fillAmount = HealthManagement.instance.CurrentHealth / 5; // Updates current health accordingly
    }
}
