using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shieldspawner : MonoBehaviour
{
    public GameObject shieldPrefab;
    public PlayerInput playerInput;
    public float waitTime = 5f;
    private bool canBePressed = true;

    public void Update()
    {
        if (playerInput.actions["Shield"].WasPerformedThisFrame() && CurrencyManager.instance.shieldLevel > 0)
        {
            SpawnShield();
        }
    }

    public void SpawnShield()
    {
        if (canBePressed)
        {
            GameObject shield = Instantiate(shieldPrefab, transform.position, Quaternion.identity, transform);
            StartCoroutine(DelayShield());
            shield.transform.SetParent(this.transform);
        }
    }

    private IEnumerator DelayShield()
    {
        canBePressed = false;
        // button.interactable = false;
        yield return new WaitForSeconds(waitTime);
        // button.interactable = true;
        canBePressed = true;
    }
}
