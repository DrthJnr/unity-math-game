using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionsGenerator : MonoBehaviour
{
    public static QuestionsGenerator Instance;
    public GameObject Question;
    private TextMeshProUGUI QuestionText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int firstN, secondN, op, rand1, rand2, answer;


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
                firstN = Random.Range(1, 20);
                secondN = Random.Range(1, 20);
                answer = firstN + secondN;
                rand1 = Random.Range(3, 40);
                rand2 = Random.Range(3, 40);
                } while (rand1 == answer || rand2 == answer || rand1 == rand2);
            } else if(GameControl.difficulty == 1)
            {
                op = Random.Range(1, 5);
                do
                {
                    firstN = Random.Range(20, 100);
                    secondN = Random.Range(20, 100);
                    answer = firstN + secondN;
                    rand1 = Random.Range(40, 200);
                    rand2 = Random.Range(40, 200);
                } while (rand1 == answer || rand2 == answer || rand1 == rand2);
            }
            else
            {
                op = Random.Range(1, 5);
                do
                {
                    firstN = Random.Range(100, 1000);
                    secondN = Random.Range(100, 1000);
                    answer = firstN + secondN;
                    rand1 = Random.Range(200, 2000);
                    rand2 = Random.Range(200, 2000);
                } while (rand1 == answer || rand2 == answer || rand1 == rand2);
            }
            

            GameControl.newQuestion = 0;
        }        
        QuestionText.text = $"Pergunta : {firstN} + {secondN}";

        scoreText.text = $"Pontos : {GameControl.score}";
    }

}