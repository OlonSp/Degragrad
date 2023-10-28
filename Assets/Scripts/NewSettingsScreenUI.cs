using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewSettingsScreenUI : MonoBehaviour
{
    public Toggle DebugModeToggle;
    public Slider musicVolume;
    public Slider soundsVolume;
    public Slider allVolume;

    private void Start()
    {
        DebugModeToggle.isOn = ModelController.isDebugging;
    }

    private void OnEnable()
    {
        DebugModeToggle.isOn = ModelController.isDebugging;
        musicVolume.value = ModelController.musicVolume;
        soundsVolume.value = ModelController.soundsVolume;
        allVolume.value = ModelController.allVolume;
    }

    public void OnMusicVolumeChanged()
    {
        ModelController.musicVolume = musicVolume.value;
    }

    public void OnSoundsVolumeChanged()
    {
        ModelController.soundsVolume = soundsVolume.value;
    }

    public void OnAllVolumeChanged()
    {
        ModelController.allVolume = allVolume.value;
    }


    void Update()
    {
        ModelController.isDebugging = DebugModeToggle.isOn;
    }
}
