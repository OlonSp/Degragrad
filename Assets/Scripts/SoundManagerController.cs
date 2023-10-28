using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerController : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }

    private static SoundManagerController me;
    public static SoundManagerController inst
    {
        get
        {
            if (me == null) me = GameObject.Find("SoundManager").GetComponent<SoundManagerController>();
            return me;
        }
    }

    public Sound[] sounds;
    public AudioClip[] backgroundMusic;
    public AudioSource source;
    public AudioSource backgroundMusicSource;

    private int backMusicIndex;

    private void Start()
    {
        OnMusicVolChanged(0);
        ModelController.OnMusicVolumeChanged += OnMusicVolChanged;
        ModelController.OnAllVolumeChanged += OnMusicVolChanged;
    }

    private void OnDestroy()
    {
        ModelController.OnMusicVolumeChanged -= OnMusicVolChanged;
        ModelController.OnAllVolumeChanged -= OnMusicVolChanged;
    }

    public void PlaySound(string name)
    {
        AudioSource sr = Instantiate(source.gameObject, transform).GetComponent<AudioSource>();
        foreach (Sound sd in sounds)
        {
            if (sd.name == name) sr.PlayOneShot(sd.clip, ModelController.soundsVolume*ModelController.allVolume);
        }
        sr.GetComponent<AudioSourceController>().active = true;
    }

    public void OnMusicVolChanged(float newVolume)
    {
        backgroundMusicSource.volume = ModelController.musicVolume*ModelController.allVolume;
    }

    private void Update()
    {
        if (!backgroundMusicSource.isPlaying || backgroundMusicSource.clip is null)
        {
            backMusicIndex += 1;
            if (backMusicIndex >= backgroundMusic.Length) backMusicIndex = 0;
            backgroundMusicSource.clip = backgroundMusic[backMusicIndex];
            backgroundMusicSource.Play();
        }
    }
}
