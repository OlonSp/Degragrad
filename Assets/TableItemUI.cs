using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TableItemUI : MonoBehaviour
{
    public TMP_Text usernameTxt;
    public TMP_Text countTxt;
    public bool isTextSet;

    public bool SetText(string username, string count)
    {
        if (isTextSet) return false;
        usernameTxt.text = username;
        countTxt.text = count;
        isTextSet = true;
        return true;
    }
}
