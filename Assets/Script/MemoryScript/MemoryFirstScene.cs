using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryFirstScene : MonoBehaviour
{
    public List<GameObject> QuestionsBgL = new List<GameObject>();
    public List<GameObject> QuestionsBgM = new List<GameObject>();
    public List<GameObject> QuestionsBgR = new List<GameObject>();
    public List<Button> ButtonsAnswer = new List<Button>();

    public GameObject QuestionsBg;
    public float questionsTime;

    private void Start()
    {
        RandomQuestions();
    }

    public void RandomQuestions()
    {
        int randomQuestions›ndexL = Random.Range(0, QuestionsBgL.Count);
        QuestionsBgL[randomQuestions›ndexL].SetActive(true);

        int randomQuestions›ndexM = Random.Range(0, QuestionsBgM.Count);
        QuestionsBgM[randomQuestions›ndexM].SetActive(true);

        int randomQuestions›ndexR = Random.Range(0, QuestionsBgR.Count);
        QuestionsBgR[randomQuestions›ndexR].SetActive(true);

        StartCoroutine(NextQuetions());
    }

    IEnumerator NextQuetions()
    {
        yield return new WaitForSeconds(questionsTime);
        QuestionsBg.SetActive(false);


    }
}
