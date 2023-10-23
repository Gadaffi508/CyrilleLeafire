using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameType : MonoBehaviour
{
    public GameObject LevelFirst;
    public GameObject SecondFirst;

    string gametype;

    private void Start()
    {
        GetGameTypeStr();

        if (gametype == "BG1")
        {
            LevelFirst.SetActive(true);
            SecondFirst.SetActive(false);
        }

        if (gametype == "BG1.5")
        {
            SecondFirst.SetActive(true);
            LevelFirst.SetActive(false);
        }
    }

    public void GetGameTypeStr()
    {
        gametype = PlayerPrefs.GetString("activeObj.name",gametype);
    }
}
