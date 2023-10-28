using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DebugScreen : MonoBehaviour
{
    public TMP_Text timeScaleTxt;
    public TMP_Text currCardTxt;
    public TMP_Text godModeTxt;
    public TMP_Text consoleLogTxt;
    public TMP_InputField inputCMD;
    public float timeScale = 1;

    void Start()
    {
        consoleLogTxt.text = ModelController.consoleLog;
        if (!(ModelController.lastCommand is null))
        {
            inputCMD.text = ModelController.lastCommand;
        }
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

        currCardTxt.text = "Current Card Num: " + ControllerUI.inst.cardManagerUI.currentCardNum.ToString();
    }

    public void EnterCommand(string command)
    {
        Log(command, false);
        ModelController.lastCommand = command;
        string[] data = command.Split(' ');
        switch (data[0])
        {
            case "/death":
                if (data.Length != 2)
                {
                    Log("Incorrect /death <index>. Ex.: /death 4");
                    return;
                }

                int deathIndex = 0;
                int.TryParse(data[1], out deathIndex);

                deathIndex = Mathf.Clamp(deathIndex, 0, 7);

                // Получаем номер коэф. смерти
                int coefIndex = Mathf.FloorToInt(deathIndex / 2);
                // Определяем (Перебор / Недобор)
                int overUnderIndex = deathIndex % 2;
                CoeffUI coef = ControllerUI.inst.coeffManager.coefficients[coefIndex];
                coef.OnDeathPercents(overUnderIndex);

                Log("Death card added");
                break;
            case "/year":
                if (data.Length != 3)
                {
                    Log("Incorrect /year <start_year> <cur_year>. Ex.: /year 1491 1980");
                    return;
                }

                int startYear = 0;
                int.TryParse(data[1], out startYear);
                startYear = Mathf.Clamp(startYear, 0, (int)Mathf.Pow(10, 5));

                int endYear = 0;
                int.TryParse(data[2], out endYear);
                endYear = Mathf.Clamp(endYear, startYear, (int)Mathf.Pow(10, 5));

                ModelController.startYear = startYear;
                ModelController.monthsCount = 0;
                ModelController.ChangeMonths((endYear - startYear) * 12);

                Log("Year changed");
                break;
            case "/coef":
                if (data.Length != 3)
                {
                    Log("Incorrect /coef <0 <= coef_id <= 3> <0 <= value <= 100>. Ex.: /coef 0 55");
                    return;
                }

                int coef_id = 0;
                int.TryParse(data[1], out coef_id);
                coef_id = Mathf.Clamp(coef_id, 0, 3);

                int value = 0;
                int.TryParse(data[2], out value);
                value = Mathf.Clamp(value, 0, 100);

                CoeffUI coefWid = ControllerUI.inst.coeffManager.coefficients[coef_id];
                coefWid.SetPercents(value);

                Log("Coef changed");
                break;
            //case "/timescale":
            //    if (data.Length != 2)
            //    {
            //        Log("Incorrect /timescale <scale>. Ex.: /timescale 0.5");
            //        return;
            //    }

            //    float timescale = 0;
            //    float.TryParse(data[1], out timescale);

            //    timescale = Mathf.Clamp(timescale, 0.01f, 100);

            //    Time.timeScale = timescale;

            //    Log("Timescale changed");
            //    break;
            case "/restart":
                SceneManager.LoadScene(0);
                Log("Loaded start menu");
                break;
            case "/help":
                Log("/death <index> - Next card is your death. 0 <= index <= 7");
                Log("/year <start_year> <cur_year> - Change year");
                Log("/coef <coef_id> <value> - Change top coefficients");
                Log("/restart - Load start menu");
                //Log("/timescale <scale> - Change Time Scale");
                break;
        }
    }

    public void Log(string message, bool ital=true)
    {
        if (ital) message = "<i>" + message + "</i>";
        ModelController.consoleLog += message + "\n";
        consoleLogTxt.text = ModelController.consoleLog;
    }
}
