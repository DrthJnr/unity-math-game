using UnityEngine;

public class WarningBehaviour : MonoBehaviour
{
    private float timer;
    [SerializeField] private float timerLimit = 2f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerLimit)
        {
            Debug.Log("Warning Destroyed!");
            Destroy(gameObject);
        }
    }
}
