using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour
{
    public CardManagerUI cardManagerUI;
    public CoefficientsManagerUI coeffManager;
    public BottomMenuUI bottomMenu;
    public ScrollBlockUI scrollBlockUI;
    public RectTransform backgroundImage;
    public GameObject wideBackImg;
    public static Vector2 scaleMultiplyer = new Vector2(1, 1);
    public static Vector2 rect = new Vector2(375f, 812f);
    private CanvasScaler canvasScaler;

    private static ControllerUI instance;

    public static ControllerUI inst
    {
        get
        {
            if (instance == null) instance = GameObject.Find("CanvasUI").GetComponent<ControllerUI>();
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        inst = this;
        if (Screen.height > Screen.width)
        {
            scaleMultiplyer = new Vector2(Screen.width / 375f, Screen.height / 812f);
        }
        else
        {
            scaleMultiplyer = new Vector2(Screen.width / 812f, Screen.height / 275f);
        }
        canvasScaler = GetComponent<CanvasScaler>();
        if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
        {
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            backgroundImage.anchorMin = new Vector2(0.5f, 0.5f);
            backgroundImage.anchorMax = new Vector2(0.5f, 0.5f);
            Vector2 size = backgroundImage.GetComponent<Image>().sprite.rect.size;
            backgroundImage.sizeDelta =  new Vector2(rect.x, rect.y);
        }
        else
        {
            wideBackImg.SetActive(false);
        }
    }
}
