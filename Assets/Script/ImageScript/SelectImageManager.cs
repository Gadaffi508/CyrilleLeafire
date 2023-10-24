using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class SelectImageManager : MonoBehaviour
{
    public int first›d;
    public GameObject FirstObj;
    public int Second›d;
    public int index;

    public Transform gridParent;
    public int trueAnswer = 0;
    public GameObject FinishedPanel;

    private void Start()
    {
        ShuffleGrid();
    }

    public void ShuffleGrid()
    {
        int childCount = gridParent.childCount;
        Transform[] children = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            children[i] = gridParent.GetChild(i);
        }

        for (int i = 0; i < childCount; i++)
        {
            int randomIndex = Random.Range(i,childCount);
            Transform temp = children[randomIndex];
            children[i] = children[randomIndex];
            children[randomIndex] = temp;
        }

        for (int i = 0; i < childCount; i++)
        {
            children[i].SetSiblingIndex(i);
        }
    }

    private void Update()
    {
        if (trueAnswer >= 6)
        {
            FinishedPanel.SetActive(true);
        }
    }
}
