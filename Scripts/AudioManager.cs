using UnityEngine.Audio;
using System;
using UnityEngine; 

[System.Serializable]

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;  //array of sounds so we can add in the inspector as many sounds as we would like

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        //keeps the audio going even when the next scene plays
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Plays the audio
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    //stops playing the audio
    public void StopPlaying (string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = 0.5f;
        s.source.pitch = 0.5f;

        s.source.Stop ();
    }
}
