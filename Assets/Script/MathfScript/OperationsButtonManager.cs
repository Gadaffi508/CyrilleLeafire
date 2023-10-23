using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperationsButtonManager : MonoBehaviour
{
    OperationsManager Opaccount;
    public List<Button> buttons = new List<Button>();

    public GameObject WinObj;
    public GameObject LoseObj;
    public float UýShowTime;

    public Text AnswerTrueText;
    public Text AnswerFalseText;
    public Text ScoreText;

    public int score = 0;

    private int TrueScore = 0;
    private int FalseScore = 0;

    string[] operations = new string[4]
    {
        "-",
        "+",
        "*",
        "/"
    };


    private void Start()
    {
        Opaccount = GetComponent<OperationsManager>();
        NewGame();
    }

    private void NewGame()
    {
        List<int> randomindex = new List<int>();

        Opaccount.RandomQueations();

        for (int i = 0; i < buttons.Count; i++)
        {
            int randomOperationIndex = UnityEngine.Random.Range(0, 4);

            while (randomindex.Contains(randomOperationIndex))
            {
                randomOperationIndex = UnityEngine.Random.Range(0, 4);
            }

            randomindex.Add(randomOperationIndex);

            string selectoperaitonsRandom = operations[randomOperationIndex];

            buttons[i].GetComponentInChildren<Text>().text = selectoperaitonsRandom.ToString();
        }
    }


    public void ClickButtons(int index)
    {
        Opaccount.OperationText.text = buttons[index].GetComponentInChildren<Text>().text;

        string buttonNumber = buttons[index].GetComponentInChildren<Text>().text;

        if (Opaccount.selectedOperation == buttonNumber) Outcome(true);
        else Outcome(false);
    }

    private void Outcome(bool Answer)
    {
        if (Answer)
        {
            WinObj.SetActive(true);
            score += 10;
            TrueScore++;
            AnswerTrueText.text = "True Answer : " + TrueScore;
            ScoreText.text = "Score : " + score;
        }
        if (!Answer)
        {
            LoseObj.SetActive(true);
            if (score > 5) score -= 5;
            FalseScore++;
            AnswerFalseText.text = "False Answer : " + FalseScore;
            ScoreText.text = "Score : " + score;
        }
        StartCoroutine(CloseObj(WinObj));
        StartCoroutine(CloseObj(LoseObj));

    }

    IEnumerator CloseObj(GameObject UýObj)
    {
        yield return new WaitForSeconds(UýShowTime);
        Opaccount.RandomQueations();
        NewGame();
        UýObj.SetActive(false);
        Opaccount.OperationText.text = "";
    }

}
