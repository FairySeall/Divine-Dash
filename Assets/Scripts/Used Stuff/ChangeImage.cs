using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{

    public Image old1Image;
    public Image old2Image;
    public Sprite yes1Image;
    public Sprite no1Image;
    public Sprite yes2Image;
    public Sprite no2Image;
    public static bool active;
    public static bool restart;

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("ToggleSelected1") == 0)
        {
            old1Image.sprite = no1Image;
            active = false;
        }
        else if (PlayerPrefs.GetInt("ToggleSelected1") == 1)
        {
            old1Image.sprite = yes1Image;
            active = true;
        }
        if (PlayerPrefs.GetInt("ToggleSelected2") == 0)
        {
            old2Image.sprite = no2Image;
            restart = false;
        }
        else if (PlayerPrefs.GetInt("ToggleSelected2") == 1)
        {
            old2Image.sprite = yes2Image;
            restart = true;
        }
    }

    public void ImageChange1()
    {
        if (old1Image.sprite == yes1Image)
        {
            old1Image.sprite = no1Image;
            PlayerPrefs.SetInt("ToggleSelected1", 0);
            active = false;
        }
        else if (old1Image.sprite == no1Image)
        {
            old1Image.sprite = yes1Image;
            PlayerPrefs.SetInt("ToggleSelected1", 1);
            active = true;
        }
    }
    public void ImageChange2()
    {
        if (old2Image.sprite == yes2Image)
        {
            old2Image.sprite = no2Image;
            PlayerPrefs.SetInt("ToggleSelected2", 0);
            restart = false;
        }
        else if (old2Image.sprite == no2Image)
        {
            old2Image.sprite = yes2Image;
            PlayerPrefs.SetInt("ToggleSelected2", 1);
            restart = true;
        }
    }
}
