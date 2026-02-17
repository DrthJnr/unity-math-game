using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Generates math questions based on the selected difficulty level.
// Refactor to include other operations in the future and improve code structure.

public class QuestionsGenerator : MonoBehaviour
{
    public static QuestionsGenerator Instance;
    public GameObject Question;
    private TextMeshProUGUI QuestionText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int firstNumber, secondNumber, op, randomOne, randomTwo, answer;


    private void Start()
    {
        GameControl.newQuestion = 1;
        QuestionText = Question.GetComponent<TextMeshProUGUI>();
        if (Instance == null)
        {
            Instance = this;
        }        
    }

    void Update()
    {        
        if (GameControl.newQuestion == 1)
        {
            if(GameControl.difficulty == 0)
            {
                op = Random.Range(1, 3);
                do
                {
                firstNumber = Random.Range(1, 20);
                secondNumber = Random.Range(1, 20);
                answer = firstNumber + secondNumber;
                randomOne = Random.Range(3, 40);
                randomTwo = Random.Range(3, 40);
                } while (randomOne == answer || randomTwo == answer || randomOne == randomTwo);
            } else if(GameControl.difficulty == 1)
            {
                op = Random.Range(1, 5);
                do
                {
                    firstNumber = Random.Range(20, 100);
                    secondNumber = Random.Range(20, 100);
                    answer = firstNumber + secondNumber;
                    randomOne = Random.Range(40, 200);
                    randomTwo = Random.Range(40, 200);
                } while (randomOne == answer || randomTwo == answer || randomOne == randomTwo);
            }
            else
            {
                op = Random.Range(1, 5);
                do
                {
                    firstNumber = Random.Range(100, 1000);
                    secondNumber = Random.Range(100, 1000);
                    answer = firstNumber + secondNumber;
                    randomOne = Random.Range(200, 2000);
                    randomTwo = Random.Range(200, 2000);
                } while (randomOne == answer || randomTwo == answer || randomOne == randomTwo);
            }
            

            GameControl.newQuestion = 0;
        }        
        QuestionText.text = $"Pergunta : {firstNumber} + {secondNumber}";
        scoreText.text = $"Pontos : {GameControl.score}";
    }

}