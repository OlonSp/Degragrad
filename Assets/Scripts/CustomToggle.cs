using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class CustomToggle : MonoBehaviour
{
    public Toggle tg;
    public GameObject checkActive;
    public GameObject checkPassive;

    private void Update()
    {
        checkActive.SetActive(tg.isOn);
        checkPassive.SetActive(!tg.isOn);
    }
}
