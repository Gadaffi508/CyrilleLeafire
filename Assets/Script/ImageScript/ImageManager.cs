using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public SelectImageManager selectImageManager;
    public GameObject gameOBJ;
    public int Card›d;
    public RectTransform ImageRectTransform;
    public GameObject DontClk;
    bool working;
    public float RotateTime = 1;
    private float Rtime;

    private void Start()
    {
        ImageRectTransform = GetComponent<RectTransform>();
    }

    public void MouseClick()
    {
        StartCoroutine(RotateImage());
    }

    private IEnumerator RotateImage()
    {
        DontClk.SetActive(true);
        Rtime = 0;
        selectImageManager.index++;

        if (selectImageManager.index == 1) { selectImageManager.first›d = Card›d; selectImageManager.FirstObj = this.gameObject; }
        if (selectImageManager.index == 2) selectImageManager.Second›d = Card›d;

        if (selectImageManager.first›d == selectImageManager.Second›d) Debug.Log("true");
        if(selectImageManager.first›d != selectImageManager.Second›d && selectImageManager.index != 1) StartCoroutine(BackRotateImage());

        if(selectImageManager.index == 2) selectImageManager.index = 0;
        
        while (RotateTime > Rtime)
        {
            Rtime += Time.deltaTime;
            ImageRectTransform.Rotate(Vector3.up);
            yield return null;
        }
        ImageRectTransform.rotation = Quaternion.Euler(0,180, 0);

        gameOBJ.SetActive(true);

        yield return new WaitForSeconds(2);
        if (!working) DontClk.SetActive(false);
    }

    private IEnumerator BackRotateImage()
    {
        working = true;
        DontClk.SetActive(true);
        yield return new WaitForSeconds(2);
        Rtime = 0;
        selectImageManager.FirstObj.GetComponent<ImageManager>().gameOBJ.SetActive(false);
        gameOBJ.SetActive(false);
        while (RotateTime > Rtime)
        {
            Rtime += Time.deltaTime;
            ImageRectTransform.Rotate(Vector3.up);
            selectImageManager.FirstObj.GetComponent<ImageManager>().ImageRectTransform.Rotate(Vector3.up);
            yield return null;
        }
        ImageRectTransform.rotation = Quaternion.Euler(0, 0, 0);
        selectImageManager.FirstObj.GetComponent<ImageManager>().ImageRectTransform.rotation = Quaternion.Euler(0, 0, 0);

        yield return new WaitForSeconds(2);
        DontClk.SetActive(false);
        working = false;
    }

}
