using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{

    public Image oldImage;
    public Sprite yesImage;
    public Sprite noImage;
    public static bool active;

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("ToggleSelected") == 0)
        {
            oldImage.sprite = noImage;
            active = false;
        }
        else
        {
            oldImage.sprite = yesImage;
            active = true;
        }
    }

    public void ImageChance()
    {
        if(oldImage.sprite == yesImage)
        {
            oldImage.sprite = noImage;
            PlayerPrefs.SetInt("ToggleSelected", 0);
            active = false;
        }
        else
        {
            oldImage.sprite = yesImage;
            PlayerPrefs.SetInt("ToggleSelected", 1);
            active = true;
        }
    }
}
