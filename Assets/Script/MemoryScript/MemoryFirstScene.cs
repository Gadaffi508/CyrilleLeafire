using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryFirstScene : MonoBehaviour
{
    public List<GameObject> QuestionsBgL = new List<GameObject>();
    public List<GameObject> QuestionsBgM = new List<GameObject>();
    public List<GameObject> QuestionsBgR = new List<GameObject>();
    public List<Sprite> Answer = new List<Sprite>();
    public List<Button> ButtonsAnswer = new List<Button>();
    public List<Image> ButtonsCheckAnswer = new List<Image>();
    public List<GameObject> ButtonsImageBg = new List<GameObject>();

    public GameObject QuestionsBg;
    public GameObject ButtonsBg;
    public float questionsTime;
    public float ButtonsTime;
    public int Trueanswer;
    public int Falseanswer;

    public Text TimeText;
    public float Times;
    public Text ScoreText;
    public Text ScoreFinishedText;
    public int Score;

    public Transform gridParent;
    public GameObject FinisPanel;

    private void Start()
    {
        RandomQuestions();
    }

    private void Update()
    {
        Times -= Time.deltaTime;

        TimeText.text = "Time : " + Times.ToString("00");
        ScoreText.text = "Score : " + Score;

        if(Times <= 0)
        {
            FinisPanel.SetActive(true);
            ScoreFinishedText.text = "Score : " + Score;
        }
    }

    public void RandomQuestions()
    {
        ClearList(QuestionsBgL);
        ClearList(QuestionsBgM);
        ClearList(QuestionsBgR);

        int randomQuestions›ndexL = Random.Range(0, QuestionsBgL.Count);
        QuestionsBgL[randomQuestions›ndexL].SetActive(true);
        Answer.Add(QuestionsBgL[randomQuestions›ndexL].GetComponent<Image>().sprite);

        int randomQuestions›ndexM = Random.Range(0, QuestionsBgM.Count);
        QuestionsBgM[randomQuestions›ndexM].SetActive(true);
        Answer.Add(QuestionsBgM[randomQuestions›ndexM].GetComponent<Image>().sprite);

        int randomQuestions›ndexR = Random.Range(0, QuestionsBgR.Count);
        QuestionsBgR[randomQuestions›ndexR].SetActive(true);
        Answer.Add(QuestionsBgR[randomQuestions›ndexR].GetComponent<Image>().sprite);

        StartCoroutine(NextQuetions());
    }

    IEnumerator NextQuetions()
    {
        yield return new WaitForSeconds(questionsTime);
        QuestionsBg.SetActive(false);
        yield return new WaitForSeconds(ButtonsTime);
        ShuffleGrid();
        ButtonsBg.SetActive(true);
    }

    public void CheckAnswer(Image buttonImage)
    {
        ButtonsCheckAnswer.Add(buttonImage);

        if (ButtonsCheckAnswer.Count > 2)
        {
            for (int i = 0; i < 3; i++)
            {
                if (ButtonsCheckAnswer[i].sprite == Answer[i])
                {
                    Trueanswer++;
                    Score += 5;
                }
                else
                {
                    Falseanswer++;
                    if (Score > 10) Score -= 1;
                }
            }

            Answer.Clear();
            ButtonsCheckAnswer.Clear();
            ButtonsBg.SetActive(false);
            ClearList(ButtonsImageBg);
            QuestionsBg.SetActive(true);
            RandomQuestions();
        }
    }

    public void ClearList(List<GameObject> list)
    {
        foreach (GameObject listt in list)
        {
            listt.SetActive(false);
        }
    }

    void ShuffleGrid()
    {
        int childCount = gridParent.childCount;
        Transform[] children = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            children[i] = gridParent.GetChild(i);
        }

        for (int i = 0; i < childCount; i++)
        {
            int randomIndex = Random.Range(i, childCount);
            Transform temp = children[i];
            children[i] = children[randomIndex];
            children[randomIndex] = temp;
        }

        for (int i = 0; i < childCount; i++)
        {
            children[i].SetSiblingIndex(i);
        }
    }
}
