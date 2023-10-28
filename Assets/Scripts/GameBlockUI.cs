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

    public void OnTableShowed()
    {
        ControllerUI.inst.cardManagerUI.SpawnCards();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowScreen(int index)
    {
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
}
