using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public List<Image> colorImage = new List<Image>();
    public List<Button> Buttons = new List<Button>();
    public List<Image> ButtonsAnswer = new List<Image>();
    public Color colors;
    public int trueAnswer;

    private void Start()
    {
        RandomColor();
        RandomImageButton();
    }

    public void RandomColor()
    {
        for (int i = 0; i < colorImage.Count; i++)
        {
            colors = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
                );

            colorImage[i].color = colors;
            ButtonsAnswer.Add(colorImage[i]);
        }
    }

    public void RandomImageButton()
    {
        int random = Random.Range(1, 4);
        for (int i = 0; i < Buttons.Count; i++)
        {
            if (random == i)
            {
                 ButtonsAnswer[i].color = Buttons[i].image.color;
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
        while (ButtonsAnswer.Contains(buttonImage))
        {
            trueAnswer++;
        }
        Debug.Log(trueAnswer);
    }
}
