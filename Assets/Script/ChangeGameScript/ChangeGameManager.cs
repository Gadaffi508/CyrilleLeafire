using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGameManager : MonoBehaviour
{
    public GameObject[] GameTypeImageBg;

    public void GameStart()
    {
        GameObject activeObj = null;

        for (int i = 0; i < GameTypeImageBg.Length; i++)
        {
            if (GameTypeImageBg[i].activeSelf)
            {
                activeObj = GameTypeImageBg[i];
                break;
            }
        }

        if (activeObj != null)
        {
            Debug.Log("Game is starting: " + activeObj.name);
            SaveGameType(activeObj);

            switch (activeObj.name)
            {
                case "BG1":
                    LoadScene(2);
                    break;
                case "BG1.5":
                    LoadScene(2);
                    break;
                case "BG2":
                    LoadScene(3);
                    break;
                case "BG2.5":
                    LoadScene(3);
                    break;
                case "BG3":
                    LoadScene(1);
                    break;
                case "BG3.5":
                    LoadScene(1);
                    break;
            }

        }
        else
        {
            Debug.Log("Choose your game");
        }
    }

    public void LoadScene(int SceneÝd)
    {
        SceneManager.LoadScene(SceneÝd);
    }

    public void SaveGameType(GameObject activeObj)
    {
        PlayerPrefs.SetString("activeObj.name", activeObj.name);
    }
}
