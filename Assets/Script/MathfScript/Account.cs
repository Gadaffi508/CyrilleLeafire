using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Account : MonoBehaviour
{
    public Text FirstNumberObj;
    public Text SecondNumberObj;
    public Text CurrentNumberObj;

    private int FirstNumber;
    private int SecondNumber;
    public int CurrentNumber;

    private void Start()
    {
        FirstNumber = Random.Range(0,100);
        SecondNumber = Random.Range(0,100);

        FirstNumberObj.text = FirstNumber.ToString();
        SecondNumberObj.text = SecondNumber.ToString();

        CurrentNumber = FirstNumber + SecondNumber;

        //CurrentNumberObj.text = CurrentNumber.ToString();
    }
}
