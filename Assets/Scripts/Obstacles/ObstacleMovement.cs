using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float minSpeed = 1f, maxSpeed = 3f;
    [SerializeField] private GameObject obstacle;
    private float movSpeed;
    public float deadZone = -7;

    void Start()
    {
        if (GameControl.difficulty == 0) // Easy mode
        {
            minSpeed = 4f;
            maxSpeed = 7f;
        }
        else if (GameControl.difficulty == 1) // Normal mode
        {
            minSpeed = 7f;
            maxSpeed = 12f;
        }
        else if (GameControl.difficulty == 2) // Hard mode
        {
            minSpeed = 12f;
            maxSpeed = 16f;
        }
        movSpeed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.down * movSpeed * Time.deltaTime; // Movement

        if (GameControl.isPaused == 1)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        OnBecameInvisible();        
    }
    private void OnTriggerEnter2D(Collider2D collider) // Collisions trigger
    {
        if (collider.CompareTag("Bullet"))
        {
            Debug.Log("Collided with Bullet");
            Destroy(gameObject);
            Destroy(collider.gameObject);           
        }
        else if (collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            HealthManagement.instance.TakeDamage(1);
        }
    }

    private void OnBecameInvisible() // Destroy obstacle when out of screen
    {
        if(transform.position.y < deadZone)
            Destroy(obstacle);
    }
}
