using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] answerPrefab;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int movSpeed = 4;
    public float deadZone = -12;
    public TextMeshProUGUI answerText, wrongAnText1, wrongAnText2;
    private int answer;

    private void Start()
    {
        answerText = answerPrefab[0].GetComponentInChildren<TextMeshProUGUI>();
        wrongAnText1 = answerPrefab[1].GetComponentInChildren<TextMeshProUGUI>();
        wrongAnText2 = answerPrefab[2].GetComponentInChildren<TextMeshProUGUI>();
        answer = QuestionsGenerator.Instance.firstNumber + QuestionsGenerator.Instance.secondNumber;
        answerText.text = $"{answer}";
        wrongAnText1.text = $"{QuestionsGenerator.Instance.randomOne}";
        wrongAnText2.text = $"{QuestionsGenerator.Instance.randomTwo}";
    }
    void Update()
    {

        transform.position = transform.position + movSpeed * Time.deltaTime * Vector3.left; // Movement

        if (transform.position.x < deadZone) // Destroy surpassed answers
        {                        
            Destroy(gameObject);            
        }
        CheckIfPaused(); // Hides answers when paused
    }

    private void OnTriggerEnter2D(Collider2D collider) // Collisions trigger
    {
        if (collider.CompareTag("Player"))
        {
            if (gameObject == answerPrefab[0])
            {
                Debug.Log("Audio play : Correto!");
                GameControl.AddScore(GameControl.difficulty);
                GameControl.newQuestion = 1;
            }
            else
            {
                Debug.Log("Audio play : Errado!");
                HealthManagement.instance.TakeDamage(1);
            }
            DestroyAllClones();
            
            // Destroy(collision.gameObject);
        }
        if (collider.CompareTag("Bullet"))
        {
            if (gameObject == answerPrefab[0])
            {
                Debug.Log("Audio play : Correto!");
                GameControl.AddScore(GameControl.difficulty);
                GameControl.newQuestion = 1;
            }
            else
            {
                Debug.Log("Audio play : Errado!");
                HealthManagement.instance.TakeDamage(1);
            }
            Destroy(collider.gameObject);
            DestroyAllClones();

            // Destroy(collision.gameObject);
        }

    }
    public void DestroyAllClones()
    {
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Answer");
        foreach (GameObject clone in clones)
        {
            Destroy(clone);
        }
    }

    void CheckIfPaused()
    {
        if (GameControl.isPaused == 1)
        {
            answerText.gameObject.SetActive(false);
            wrongAnText1.gameObject.SetActive(false);
            wrongAnText2.gameObject.SetActive(false);
        }
        else
        {
            answerText.gameObject.SetActive(true);
            wrongAnText1.gameObject.SetActive(true);
            wrongAnText2.gameObject.SetActive(true);
        }
    }

}