using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugScreen : MonoBehaviour
{
    public TMP_Text timeScaleTxt;
    public TMP_Text currCardTxt;
    public TMP_Text godModeTxt;
    public float timeScale = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftBracket))
        {
            timeScale -= 0.25f;
        }
        if (Input.GetKeyUp(KeyCode.RightBracket))
        {
            timeScale += 0.25f;
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            timeScale = 10f;
        }
        godModeTxt.gameObject.SetActive(ControllerUI.inst.godMod);
        Time.timeScale = Mathf.Max(0, timeScale);
        timeScaleTxt.text = "Time scale: " + timeScale.ToString();

        currCardTxt.text = "Current Crad Num: " + ControllerUI.inst.cardManagerUI.currentCardNum.ToString();
    }
}
