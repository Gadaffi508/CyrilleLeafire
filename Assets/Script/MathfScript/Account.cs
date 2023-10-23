using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Account : MonoBehaviour
{
    public Text FirstNumberObj;
    public Text SecondNumberObj;
    public Text CurrentNumberObj;
    public Text CurrentText;
    public Text OperationText;
    public Text TimeText;
    public int CurrentNumber;
    public float Counter;

    private int FirstNumber;
    private int SecondNumber;

    public GameObject Levelmenu;

    public Text LevelScoreText;

    string[] operations = new string[4]
    {
        "-",
        "+",
        "*",
        "/"
    };

    ButtonManager btnManager;

    private void Start()
    {
        RandomQueations();
        btnManager = GetComponent<ButtonManager>();
    }

    public void RandomQueations()
    {
        FirstNumber = Random.Range(0, 10);
        SecondNumber = Random.Range(0, 10);

        while (SecondNumber > FirstNumber)
        {
            FirstNumber = Random.Range(0, 10);
            SecondNumber = Random.Range(0, 10);
        }

        FirstNumberObj.text = FirstNumber.ToString();
        SecondNumberObj.text = SecondNumber.ToString();

        int randomOperationIndex = Random.Range(0, 4);

        string selectedOperation = operations[randomOperationIndex];

        OperationText.text = operations[randomOperationIndex].ToString();

        int result = 0;

        switch (selectedOperation)
        {
            case "-":
                result = FirstNumber - SecondNumber;
                break;
            case "+":
                result = FirstNumber + SecondNumber;
                break;
            case "*":
                result = FirstNumber * SecondNumber;
                break;
            case "/":
                if (SecondNumber != 0)
                {
                    result = FirstNumber / SecondNumber;
                }
                break;
        }

        CurrentNumber = result;

        CurrentText.text = CurrentNumber.ToString();
    }

    private void Update()
    {
        if (Counter <= 0)
        {
            Levelmenu.SetActive(true);
            Counter = 0;
            LevelScoreText.text = "Score : " + btnManager.score.ToString();
        }
        else
        {
            Counter -= Time.deltaTime;
            TimeText.text = "Time : " + Counter.ToString("00");
        }
    }
}
