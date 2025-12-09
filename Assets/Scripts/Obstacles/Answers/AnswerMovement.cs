using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] answerPrefab;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int movSpeed = 5;
    public float deadZone = -12;
    public TextMeshProUGUI answerText, wrongAnText1, wrongAnText2;
    private HealthManagement healthManagement;
    private int answer;

    private void Start()
    {
        healthManagement = GameObject.FindObjectOfType<HealthManagement>();
        answerText = answerPrefab[0].GetComponentInChildren<TextMeshProUGUI>();
        wrongAnText1 = answerPrefab[1].GetComponentInChildren<TextMeshProUGUI>();
        wrongAnText2 = answerPrefab[2].GetComponentInChildren<TextMeshProUGUI>();
        answer = QuestionsGenerator.Instance.firstN + QuestionsGenerator.Instance.secondN;
        Debug.Log(answer);
        answerText.text = $"{answer}";
        wrongAnText1.text = $"{QuestionsGenerator.Instance.rand1}";
        wrongAnText2.text = $"{QuestionsGenerator.Instance.rand2}";
    }
    void Update()
    {

        transform.position = transform.position + movSpeed * Time.deltaTime * Vector3.left; // Movement

        if (transform.position.x < deadZone) // Destroy surpassed answers
        {                        
            Destroy(gameObject);            
        }        
    }

    private void OnTriggerEnter2D(Collider2D collider) // Collisions trigger
    {
        if (collider.CompareTag("Player"))
        {
            if (gameObject == answerPrefab[0])
            {
                Debug.Log("Correct!");
                GameControl.score++;
                GameControl.newQuestion = 1;
            }
            else
            {
                Debug.Log("Incorrect.");
                healthManagement.TakeDamage(1);
            }
            DestroyAllClones();
            
            // Destroy(collision.gameObject);
        }
        if (collider.CompareTag("Bullet"))
        {
            if (gameObject == answerPrefab[0])
            {
                Debug.Log("Correct!");
                GameControl.score++;
                GameControl.newQuestion = 1;
            }
            else
            {
                Debug.Log("Incorrect.");
                healthManagement.TakeDamage(1);
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

}