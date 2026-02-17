using UnityEngine;

public class ShieldDisable : MonoBehaviour
{    
    void Start()
    {
        // Disable shield if shield level is 0
        if (CurrencyManager.instance.shieldLevel == 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
