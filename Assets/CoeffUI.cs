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

    private Color minusColor = new Color(1, 0.3787588f, 0.3725491f);
    private Color plusColor = new Color(0.3726415f, 1, 0.3926642f);

    public void ChangePercents(float delta)
    {
        SetPercents(percents + delta);
    }

    public void SetPercents(float prs)
    {
        percents = Mathf.Clamp(prs, 0, 100);
        if (percents == 0)
        {
            ControllerUI.inst.cardManagerUI.spawnDeath = true;
            ControllerUI.inst.cardManagerUI.ClearQueue();
            ControllerUI.inst.cardManagerUI.AddCardToQueue(UnderDeathCard);
        }
        else if (percents == 100)
        {
            ControllerUI.inst.cardManagerUI.spawnDeath = true;
            ControllerUI.inst.cardManagerUI.ClearQueue();
            ControllerUI.inst.cardManagerUI.AddCardToQueue(OverDeathCard);
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
    }
}
