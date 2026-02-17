using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    public float shieldDuration = 5f;

    void Start()
    {
        Destroy(gameObject, shieldDuration);
        CheckShieldLevel();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Obstacle"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }

    private void CheckShieldLevel()
    {
        int shieldLevel = PlayerPrefs.GetInt("NivelEscudo", 0);

        switch (shieldLevel)
        {
            case 0:
                shieldDuration = 0f;
                break;
            case 1:
                shieldDuration = 5f;
                break;
            case 2:
                shieldDuration = 7f;
                break;
            default:
                shieldDuration = 5f;
                break;
        }
    }
}
