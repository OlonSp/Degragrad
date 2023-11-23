using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameBlockUI : MonoBehaviour
{
    public GameObject[] screens;
    public GameObject newBackDesign;
    public StartScreen startScreen;
    public NewCharactersScreenUI newCharactersScreen;
    public NewCharacterScreenUI newCharacterScreen;
    private List<int> screenHist = new List<int>();

    private void Start()
    {
        newCharactersScreen.OnCharacterSelected += OnCharacterSelected;
    }

    public void OnCharacterSelected(Character character)
    {
        newCharacterScreen.SetData(character);
        ShowScreen(13);
    }

    public void OnTableShowed()
    {
        ControllerUI.inst.cardManagerUI.SpawnCards();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseBtn()
    {
        ShowScreen(0);
        // Code for back btn
        //if (screenHist.Count > 1)
        //{
        //    int index = screenHist[screenHist.Count - 2];
        //    screenHist.RemoveAt(screenHist.Count - 1);
        //    screenHist.RemoveAt(screenHist.Count - 1);
        //    ShowScreen(index);
        //}
        //else
        //{
        //    ShowScreen(0);
        //}
    }

    public void ShowScreen(int index)
    {
        screenHist.Add(index);
        if (screenHist.Count > 10) screenHist.RemoveAt(0);
        startScreen.checkClicks = index == 0;
        newBackDesign.SetActive(false);
        for (int i = 0;i<screens.Length;i++)
        {
            screens[i].SetActive(i == index);
            if (i == index && index > 7)
            {
                newBackDesign.SetActive(true);
            }
        }
    }

    public void ResetProgress()
    {
        ControllerUI.inst.coeffManager.ResetDefaultValues();
    }
}
