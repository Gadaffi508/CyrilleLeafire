using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemorySecondmanager : MonoBehaviour
{
    public Text QuestionsText;
    public Text AnswersText;
    public int Answer;
    public int CheckAnswerCount;
    public int CheckAnswer;
    public float QuestionsTime;
    public GameObject QuestionsBg;
    public GameObject ButtonsBg;

    public GameObject FinishedPanel;

    public Text scoreText;
    public Text scoreFinishedText;
    public Text TimeText;
    public float timeS;
    public int score;

    private void Start()
    {
        RandomQuestions();
    }

    private void Update()
    {
        timeS -= Time.deltaTime;

        scoreText.text = "Score : " + score;
        TimeText.text = "Time : " + timeS.ToString("00");

        if (timeS <= 0)
        {
            scoreFinishedText.text ="Score : " + score;
            timeS = 0;
            FinishedPanel.SetActive(true);
        }
    }

    private void RandomQuestions()
    {
        CheckAnswerCount = 0;
        CheckAnswer = 0;
        Answer = Random.Range(100000, 9000000);
        AnswersText.text = "";
        QuestionsText.text = Answer.ToString();
        CheckAnswerCount = QuestionsText.text.Length;

        StartCoroutine(CloseQuestions());
    }

    IEnumerator CloseQuestions()
    {
        yield return new WaitForSeconds(QuestionsTime);
        QuestionsBg.SetActive(false);
        yield return new WaitForSeconds(QuestionsTime-.5f);
        ButtonsBg.SetActive(true);
        AnswersText.gameObject.SetActive(true);
    }

    public void ButtonAnswer(int Value)
    {
        AnswersText.text += Value.ToString();
        CheckAnswer++;
        if (CheckAnswerCount == CheckAnswer)
        {
            if (AnswersText.text == QuestionsText.text)
            {
                score += 15;
            }
            else
            {
                if(score > 10) score -= 5;
            }

            StartCoroutine(NewQuestions());
        }
    }

    IEnumerator NewQuestions()
    {
        ButtonsBg.SetActive(false);
        AnswersText.gameObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        RandomQuestions();
        QuestionsBg.SetActive(true);
    }
}
