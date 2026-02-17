using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSpawner : MonoBehaviour
{    
    [SerializeField] private GameObject[] answerPrefabs;
    public float spawnRateSeconds = 6f;
    private float[] height = { -2.6f, 0, 2.6f };
    private float timer = 0;

    private void Start()
    {
        if (answerPrefabs.Length != 3)
        {
            Debug.LogError("Answer Prefabs must have 3.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {        
        CheckPausedGame();
        ShuffleAnswerValues();
    }

    void SpawnAnswerObject()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i != 1)
            {
                Instantiate(answerPrefabs[i], new Vector3(transform.position.x, transform.position.y + height[i], 0), transform.rotation);
            }
            else
            {
                Instantiate(answerPrefabs[i], new Vector3(transform.position.x - 0.1f, transform.position.y + height[i], 0), transform.rotation);
            }
        }
    }
    // Fisher-Yates
    void Shuffle(GameObject[] array) // Shuffles the answers values
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    void ShuffleAnswerValues() // Shuffles the answers values using a timer
    {
        if (timer < spawnRateSeconds)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Shuffle(answerPrefabs);
            SpawnAnswerObject();
            timer = 0;
        }
    }

    void CheckPausedGame()
    {
        if (GameControl.isPaused == 1)
        {
            Time.timeScale = 0f;
        }
        else
        { Time.timeScale = 1f; };
    }
}