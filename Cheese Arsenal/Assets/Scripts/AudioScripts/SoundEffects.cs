using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;

    public void Gunshot()
    {
        src.clip = sfx1;
        src.Play();
    }

    public void Explosion()
    {
        src.clip = sfx2;
        src.Play();
    }

    public void PlayerDeath()
    {
        src.clip = sfx3;
        src.Play();
    }
}
