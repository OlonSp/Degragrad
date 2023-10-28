using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartScreen : MonoBehaviour, IPointerClickHandler
{
    public bool checkClicks;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (checkClicks)
        {
            ControllerUI.inst.gameBlockUI.GetComponent<Animator>().Play("StartGame");
        }
    }
}
