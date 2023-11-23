using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    public static int startYear = 1491;
    public static int yearsCount;
    public static int monthsCount;

    public static string consoleLog;
    public static string lastCommand;

    public delegate void SoundChangedVolumeDelegate(float newVolume);

    public static SoundChangedVolumeDelegate OnMusicVolumeChanged;
    public static SoundChangedVolumeDelegate OnSoundsVolumeChanged;
    public static SoundChangedVolumeDelegate OnAllVolumeChanged;

    public static bool isDebugging
    {
        get
        {
            if (!PlayerPrefs.HasKey("debugging"))
            {
                PlayerPrefs.SetInt("debugging", 0);
            }
            return PlayerPrefs.GetInt("debugging") == 1;
        }
        set
        {
            if (value)
            {
                PlayerPrefs.SetInt("debugging", 1);
            }
            else
            {
                PlayerPrefs.SetInt("debugging", 0);
            }
        }
    }

    public static float musicVolume
    {
        get
        {
            if (!PlayerPrefs.HasKey("musicVolume"))
            {
                PlayerPrefs.SetFloat("musicVolume", 0.5f);
            }
            return PlayerPrefs.GetFloat("musicVolume");
        }
        set
        {
            PlayerPrefs.SetFloat("musicVolume", value);
            OnMusicVolumeChanged?.Invoke(value);
        }
    }
    
    public static float soundsVolume
    {
        get
        {
            if (!PlayerPrefs.HasKey("soundsVolume"))
            {
                PlayerPrefs.SetFloat("soundsVolume", 0.5f);
            }
            return PlayerPrefs.GetFloat("soundsVolume");
        }
        set
        {
            PlayerPrefs.SetFloat("soundsVolume", value);
            OnSoundsVolumeChanged?.Invoke(value);
        }
    }

    public static float allVolume
    {
        get
        {
            if (!PlayerPrefs.HasKey("allVolume"))
            {
                PlayerPrefs.SetFloat("allVolume", 1f);
            }
            return PlayerPrefs.GetFloat("allVolume");
        }
        set
        {
            PlayerPrefs.SetFloat("allVolume", value);
            OnAllVolumeChanged?.Invoke(value);
        }
    }

    public static void ChangeMonths(int delta)
    {
        monthsCount += delta;
        yearsCount = monthsCount / 12;
        ControllerUI.inst.bottomMenu.yearCounter.SetNumber((yearsCount + startYear).ToString());
        ControllerUI.inst.bottomMenu.SetMonths(monthsCount);
    }

    public static void SetCoeff(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static float GetCoeff(string key)
    {
        return PlayerPrefs.GetFloat(key, 50);
    }

    public static int TryGetIntValue(string key, int defaultValue)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public static string TryGetStringValue(string key, string defaultValue)
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    public static void SetDefaults()
    {
        monthsCount = 0;
        yearsCount = 0;
    }
}
