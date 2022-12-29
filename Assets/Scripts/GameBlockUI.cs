using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameBlockUI : MonoBehaviour
{
    public GameObject[] screens;

    public void OnTableShowed()
    {
        ControllerUI.inst.cardManagerUI.SpawnCards();
    }

    public void ShowScreen(int index)
    {
        for (int i = 0;i<screens.Length;i++)
        {
            screens[i].SetActive(i == index);
        }
    }
}
