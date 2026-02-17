using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class ShootingFunction : MonoBehaviour
{
    private bool canBePressed = true;
    public GameObject bullet;
    public float waitTime = 1.5f;
    public PlayerInput playerInput;
    public UnityEngine.UI.Button button;

    void Update()
    {
        if (playerInput.actions["Shoot"].WasPerformedThisFrame())
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (canBePressed)
        {            
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            StartCoroutine(DelayButton());
        }
    }

    private IEnumerator DelayButton()
    {
        canBePressed = false;
        button.interactable = false;
        yield return new WaitForSeconds(waitTime);
        button.interactable = true;
        canBePressed = true;
    }
}
