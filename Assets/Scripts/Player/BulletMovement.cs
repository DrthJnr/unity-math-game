using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float deadZone = 12;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject obstacle;
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * bulletSpeed) * Time.deltaTime;

        if (transform.position.x > deadZone)
        {
            Destroy(bullet);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Answer"))
        {
            Destroy(gameObject);
        }
        else if (collider.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}
