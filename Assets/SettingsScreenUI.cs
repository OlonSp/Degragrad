using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsScreenUI : MonoBehaviour
{
    public TMP_Text versionTxt;
    void Start()
    {
        versionTxt.text = Application.version;
    }
}
