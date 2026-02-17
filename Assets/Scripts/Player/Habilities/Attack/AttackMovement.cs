using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMovement : MonoBehaviour
{
    float rotationPerSec = -240f;
    [SerializeField] private float bulletSpeed = 5f, deadZone = 12;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject obstacle;
    // Update is called once per frame
    void Update()
    {
        float rotation = rotationPerSec * Time.deltaTime;
        float curvRotation = transform.localRotation.eulerAngles.z;
        transform.position += (Vector3.right * bulletSpeed) * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curvRotation + rotation));
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
