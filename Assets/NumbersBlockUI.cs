using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumbersBlockUI : MonoBehaviour
{
    public Image[] numbers;
    public Sprite[] numbTextures;

    private void Start()
    {
        SetNumber("1941");
    }

    public void SetNumber(string nmb)
    {
        for (int i = 0;i<nmb.Length;i++)
        {
            numbers[i].sprite = numbTextures[int.Parse(nmb[i].ToString())];
        }
    }
}
