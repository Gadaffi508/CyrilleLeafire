using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    Account account;
    public Button[] buttons;

    public GameObject WinObj;
    public GameObject LoseObj;

    public float UýShowTime;

    public Text AnswerTrueText;
    public Text AnswerFalseText;
    public Text ScoreText;

    public int score = 0;

    private int TrueScore = 0;
    private int FalseScore = 0;

    private void Start()
    {
        account = GetComponent<Account>();
        NewGame();
    }

    private void NewGame()
    {
        int CurrentÝndex = Random.Range(0, buttons.Length);

        for (int i = 0; i < buttons.Length; i++)
        {
            int randomnumber = Random.Range(1, 100);
            if (i == CurrentÝndex)
            {
                randomnumber = account.CurrentNumber;
                buttons[i].GetComponentInChildren<Text>().text = randomnumber.ToString();
            }
            else
            {
                buttons[i].GetComponentInChildren<Text>().text = randomnumber.ToString();
            }

        }
    }

    public void ClickButtons(int index)
    {
        account.CurrentNumberObj.text = buttons[index].GetComponentInChildren<Text>().text;

        int buttonNumber = int.Parse(buttons[index].GetComponentInChildren<Text>().text);

        if (account.CurrentNumber == buttonNumber) Outcome(true);
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
        account.RandomQueations();
        NewGame();
        UýObj.SetActive(false);
        account.CurrentNumberObj.text = "";
    }
}
