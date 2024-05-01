using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource musicSrc;
    public AudioSource buttonSrc;
    public AudioClip sfx;
    public AudioClip music;

    private void Start()
    {
        musicSrc.clip = music;
        musicSrc.Play();
    }

    public void Gunshot()
    {
        buttonSrc.clip = sfx;
        buttonSrc.Play();
    }
}

