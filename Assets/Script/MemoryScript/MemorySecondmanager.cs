using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemorySecondmanager : MonoBehaviour
{
    public Text QuestionsText;
    public Text AnswersText;
    public int Answer;
    public float QuestionsTime;
    public GameObject QuestionsBg;
    public GameObject ButtonsBg;

    public List<Button> AnswerButtons = new List<Button>();

    private void Start()
    {
        RandomQuestions();
    }

    private void RandomQuestions()
    {
        Answer = Random.Range(100000, 9000000);
        QuestionsText.text = Answer.ToString();

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
}
