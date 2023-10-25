using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public List<Image> colorImage = new List<Image>();
    public List<Button> Buttons = new List<Button>();
    public List<Image> ButtonsAnswer = new List<Image>();
    public Color colors;
    public Text TimeText;
    public Text ScoreText;
    public Text FScoreText;
    public int Score;
    public GameObject FinishedPanel;
    public float time = 60;


    private void Start()
    {
        RandomColor();
        RandomImageButton();
    }

    public void RandomColor()
    {
        StartCoroutine(ButtonsActive());

        foreach (Image image in colorImage)
        {
            Color randomColor = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );

            image.color = randomColor;
            ButtonsAnswer.Add(image);
        }
    }

    public void RandomImageButton()
    {
        int correctButtonIndex = Random.Range(0, Buttons.Count);
        Color correctColor = ButtonsAnswer[Random.Range(0, 3)].color;

        for (int i = 0; i < Buttons.Count; i++)
        {
            if (i == correctButtonIndex)
            {
                Buttons[i].image.color = correctColor;
            }
            else
            {
                Buttons[i].image.color = new Color(
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f)
                );
            }
        }
    }

    public void ButtonColorManager(Image buttonImage)
    {
        foreach (Image colorImages in colorImage)
        {
            if (colorImages.color == buttonImage.color)
            {
                Score += 10;
                RandomColor();
                RandomImageButton();
            }
            else
            {
                if(Score > 15) Score -= 5;
            }
        }
    }

    IEnumerator ButtonsActive()
    {
        yield return new WaitForSeconds(.5f);

        foreach (var Button in Buttons)
        {
            Button.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        time -= Time.deltaTime;
        TimeText.text = "Time : " + time.ToString("00");
        ScoreText.text = "Score : " + Score;

        if(time <= 0)
        {
            FScoreText.text = " Score : " + Score;
            FinishedPanel.SetActive(true);
        }
    }
}
