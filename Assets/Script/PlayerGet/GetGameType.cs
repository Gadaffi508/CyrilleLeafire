using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetGameType : MonoBehaviour
{
    public string firstlevelname;
    public GameObject LevelFirst;
    public string secondlevelname;
    public GameObject SecondFirst;

    string gametype;

    private void Start()
    {
        GetGameTypeStr();

        if (gametype == firstlevelname)
        {
            LevelFirst.SetActive(true);
            SecondFirst.SetActive(false);
        }

        if (gametype == secondlevelname)
        {
            SecondFirst.SetActive(true);
            LevelFirst.SetActive(false);
        }
    }

    public void GetGameTypeStr()
    {
        gametype = PlayerPrefs.GetString("activeObj.name",gametype);
    }

    public void BackMenuLoad(int Scene›d)
    {
        SceneManager.LoadScene(Scene›d);
    }
}
