using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;

    public bool active = false;

    void Update()
    {
        if (active && !source.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        ModelController.OnSoundsVolumeChanged += OnSoundVolumeChanged;
    }

    public void OnSoundVolumeChanged(float newVolume)
    {
        source.volume = newVolume;
    }

    private void OnDestroy()
    {
        ModelController.OnSoundsVolumeChanged -= OnSoundVolumeChanged;
    }
}
