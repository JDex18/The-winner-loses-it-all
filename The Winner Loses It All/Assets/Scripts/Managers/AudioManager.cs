using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Controller controller;
    public Sound[] sounds;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string name)
    {
        foreach (Sound s in sounds)
        {
            if(s.name == name)
            {
                if((name == "Ambiente" && controller.music == false) || (name != "Ambiente" && controller.soundEffects == false))
                {
                    return;
                }

                else
                {
                    s.source.Play();
                    return;
                } 
            }
        }

    }

    public void parar(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.Pause();
                return;
            }
        }
    }

    public void reanudar(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.UnPause();
                return;
            }
        }
    }
}
