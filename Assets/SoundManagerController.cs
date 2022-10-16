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
    public AudioSource source;

    public void PlaySound(string name)
    {
        AudioSource sr = Instantiate(source, transform);
        foreach (Sound sd in sounds)
        {
            if (sd.name == name) sr.PlayOneShot(sd.clip);
        }
    }
}
