using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomMenuUI : MonoBehaviour
{
    public NumbersBlockUI yearCounter;
    public TMP_Text monthText;
    private string monthFormat = "{0} мес.";

    public void SetMonths(int count)
    {
        monthText.text = string.Format(monthFormat, count);
    }
}
