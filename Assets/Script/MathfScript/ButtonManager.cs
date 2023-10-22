using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    Account account;
    public List<Button> buttons;

    private void Start()
    {
        account = GetComponent<Account>();
        NewGame();
    }

    private void NewGame()
    {
        int Current›ndex = Random.Range(0,buttons.Count);

        for (int i = 0; i < buttons.Count; i++)
        {
            int randomnumber = Random.Range(1,1000);
            if (i == Current›ndex)
            {
                randomnumber = account.CurrentNumber;
            }

            buttons[i].GetComponentInChildren<Text>().text = randomnumber.ToString();
        }
    }

    public void ClickButtons()
    {

    }
}
