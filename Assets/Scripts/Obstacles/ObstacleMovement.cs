using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float minSpeed = 1f, maxSpeed = 3f;
    [SerializeField] private GameObject obstacle;    
    private HealthManagement healthManagement;
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
        healthManagement = GameObject.FindObjectOfType<HealthManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.down * movSpeed * Time.deltaTime; // Movement

        if (transform.position.y < deadZone) // Destroy surpassed obstacles
        {
            Destroy(obstacle);
        }        
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
            healthManagement.TakeDamage(1);
        }
    }
}
