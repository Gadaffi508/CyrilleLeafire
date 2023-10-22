using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameType : MonoBehaviour
{
    string gametype;

    private void Start()
    {
        GetGameTypeStr();

        Debug.Log(gametype);
    }

    public void GetGameTypeStr()
    {
        gametype = PlayerPrefs.GetString("activeObj.name",gametype);
    }
}
