using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle, warning;
    [SerializeField] private float heightOffset = 1.8f;
    private float rRange;
    public float spawnDelay = 10f;
    private float timer = 0, diffTimer = 0, warningTimer = 0;
    private int isWarningSpawned = 0;

    // Update is called once per frame
    void Update()
    {               
        if (GameControl.stopGame == 1)
        {
            Time.timeScale = 0f;
        } else 
        { Time.timeScale = 1f; };

        diffTimer += Time.deltaTime;
        warningTimer += Time.deltaTime;
        if (warningTimer >= spawnDelay)
        {
            SpawnWarning();
            warningTimer = 0;
        }
        if (isWarningSpawned == 1)
        {
            timer += Time.deltaTime;
            if (timer >= 0.8f)
            {
                SpawnObstacle();
                timer = 0;                
            }
        }

        switch (GameControl.difficulty)
        {
            case 0:
                if (diffTimer >= 10 && diffTimer <= 11)
                {
                    spawnDelay = 7f;
                }
                else if (diffTimer >= 15 && diffTimer <= 16)
                {                    
                    spawnDelay = 5f;
                }
                    break;
            case 1:
                if (diffTimer <= 2)
                {                    
                    spawnDelay = 6f;
                }
                if (diffTimer >= 10 && diffTimer <= 11)
                {                    
                    spawnDelay = 4f;
                }
                else if (diffTimer >= 15 && diffTimer <= 16)
                {                    
                    spawnDelay = 1.5f;
                }
                break;
            case 2:
                if (diffTimer <= 2)
                {
                    spawnDelay = 7f;
                }
                if (diffTimer >= 10 && diffTimer <= 11)
                {
                    spawnDelay = 3f;
                }
                 if (diffTimer >= 2 && diffTimer <= 21)
                {
                    spawnDelay = 1; // 1.5f
                }
                break;

        }

    }
    void SpawnWarning()
    {
        float lowestPoint = transform.position.x - heightOffset;
        float highestPoint = transform.position.x + heightOffset;
        rRange = Random.Range( lowestPoint, highestPoint );
        Instantiate(warning, new Vector3(rRange, 3), transform.rotation);
        isWarningSpawned = 1;

    }


    void SpawnObstacle()
    {
        Instantiate(obstacle, new Vector3(rRange, transform.position.y, 0), transform.rotation);
        isWarningSpawned = 0;
    }
}