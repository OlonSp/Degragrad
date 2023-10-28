using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour
{
    public CardManagerUI cardManagerUI;
    public BlackScreen blackScreen;
    public CoefficientsManagerUI coeffManager;
    public BottomMenuUI bottomMenu;
    public ScrollBlockUI scrollBlockUI;
    public GameBlockUI gameBlockUI;
    public RectTransform backgroundImage;
    public RectTransform wideBackImg;
    public DebugScreen debugScreen;
    public static Vector2 scaleMultiplyer = new Vector2(1, 1);
    public static Vector2 rect = new Vector2(375f, 812f);
    public Rect screen;
    private CanvasScaler canvasScaler;
    public GameObject webBlock;
    public bool godMod;

    public Theme[] themes;

    public RuntimePlatform platform;
    public bool AutoDetectPlatform;

    private static ControllerUI instance;
    [HideInInspector]
    public Sprite curDeathBackground;



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

    private void Update()
    {
        debugScreen.gameObject.SetActive(ModelController.isDebugging);
        if (ModelController.isDebugging && !debugScreen.inputCMD.isFocused)
        {
            if (Input.GetKeyUp(KeyCode.L))
            {
                foreach (CoeffUI cf in coeffManager.coefficients)
                {
                    cf.SetPercents(5);
                }

            }
            if (!(cardManagerUI.activeCard is null) && cardManagerUI.activeCard.state == CardUI.CardStates.Default)
            {
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    cardManagerUI.MoveCardToLeft();
                }
                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    cardManagerUI.MoveCardToRight();
                }
            }
            if (Input.GetKeyUp(KeyCode.G))
            {
                godMod = !godMod;
            }
        }
    }

    private void Start()
    {
    }

    private void Awake()
    {
        inst = this;
        Application.targetFrameRate = 300;
        
        if (Screen.height > Screen.width)
        {
            scaleMultiplyer = new Vector2(Screen.width / 375f, Screen.height / 812f);
        }
        else
        {
            scaleMultiplyer = new Vector2(Screen.width / 812f, Screen.height / 275f);
        }
        canvasScaler = GetComponent<CanvasScaler>();
        if (AutoDetectPlatform) platform = Application.platform;
        if (platform != RuntimePlatform.Android && platform != RuntimePlatform.IPhonePlayer)
        {
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            wideBackImg.anchorMin = new Vector2(0, 0);
            wideBackImg.anchorMax = new Vector2(1, 1);
            wideBackImg.localPosition = Vector3.zero;
            wideBackImg.sizeDelta = Vector2.zero;
            backgroundImage.anchorMin = new Vector2(0.5f, 0.5f);
            backgroundImage.anchorMax = new Vector2(0.5f, 0.5f);
            Vector2 size = backgroundImage.GetComponent<Image>().sprite.rect.size;
            backgroundImage.sizeDelta =  new Vector2(rect.x, rect.y);
        }
        else
        {
            wideBackImg.GetComponent<Animator>().enabled = true;
            //wideBackImg.SetActive(false);
        }
        screen = GetComponent<RectTransform>().rect;
    }

    public void SetTheme(string name)
    {
        foreach (Theme th in themes)
        {
            foreach (GameObject go in th.objects)
            {
                go.SetActive(th.name == name);
            }
        }
    }
}
