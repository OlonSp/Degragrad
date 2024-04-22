using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoeffUI : MonoBehaviour
{
    public float percents;
    public Image imageFill;
    private float currentPercents;
    private float time;

    public CardInfo OverDeathCard;
    public CardInfo UnderDeathCard;

    public Sprite OverDeathBack;
    public Sprite UnderDeathBack;

    public string soundName;

    public RectTransform flagBackground;

    [HideInInspector]
    public float targetHeight;

    [HideInInspector]
    public float smooth;

    private float heightVelocity;

    public string coeffKey;

    private Color minusColor = new Color(1, 0.3787588f, 0.3725491f);
    private Color plusColor = new Color(0.3726415f, 1, 0.3926642f);

    public void ChangePercents(float delta)
    {
        SetPercents(percents + delta);
    }

    public void OnDeathPercents(int death_id = 0)
    {
        if (death_id == 0)
        {
            ControllerUI.inst.cardManagerUI.spawnDeath = UnderDeathCard;
            ControllerUI.inst.curDeathBackground = UnderDeathBack;
        }
        else
        {
            ControllerUI.inst.cardManagerUI.spawnDeath = OverDeathCard;
            ControllerUI.inst.curDeathBackground = OverDeathBack;
        }
    }

    public void SetPercents(float prs)
    {
        percents = Mathf.Clamp(prs, 0, 100);
        if (ControllerUI.inst.godMod) percents = Mathf.Clamp(prs, 5, 95);
        // ялепрэ
        if (percents == 0)
        {
            OnDeathPercents();
        }
        else if (percents == 100)
        {
            OnDeathPercents(1);
        }
        else
        {
            ModelController.SetCoeff(coeffKey, percents);
        }
        currentPercents = imageFill.fillAmount;
        time = 0;
    }

    void Update()
    {
        time = Mathf.Min(1, Mathf.Max(0, time + (Time.deltaTime)));
        if (currentPercents < percents / 100)
        {
            imageFill.color = Color.Lerp(Color.white, plusColor, EasingFunction.ParabolaBack(0, 1, time));
        }
        else
        {
            imageFill.color = Color.Lerp(Color.white, minusColor, EasingFunction.ParabolaBack(0, 1, time));
        }
        imageFill.fillAmount = EasingFunction.EaseOutCubic(currentPercents, EasingFunction.ShadedOutIn(0, 1, percents / 100), time);
        flagBackground.sizeDelta = new Vector2(flagBackground.sizeDelta.x, Mathf.SmoothDamp(flagBackground.sizeDelta.y, targetHeight, ref heightVelocity, smooth));
    }
}
