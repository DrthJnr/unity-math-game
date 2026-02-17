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
        if (GameControl.isPaused == 1)
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
                SetGameDifficulty(11f, 7f, 15f, 5f, 60f, 4f);
                break;
            case 1:
                SetGameDifficulty(2f, 6f, 10f, 4f, 20f, 1.5f);
                break;
            case 2:
                SetGameDifficulty(2f, 7f, 10f, 3f, 20f, 1f);                
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

    private void SetGameDifficulty(float timerOne, float spawnDelayOne, float timerTwo, float spawnDelayTwo, float timerThree, float spawnDelayThree)
    {
     if (diffTimer <= timerOne)
                {
                    spawnDelay = spawnDelayOne;
                }
                if (diffTimer >= timerTwo && diffTimer <= timerTwo + 1)
                {
                    spawnDelay = spawnDelayTwo;
                }
                 if (diffTimer >= timerThree && diffTimer <= timerThree + 1)
                {
                    spawnDelay = spawnDelayThree;
                }   
    }
}