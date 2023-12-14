using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    public AudioSource src;
    public AudioClip src1;
    private bool isPlaying = false;

    public void ToggleAudio()
    {
        if (isPlaying)
        {
            src.Stop();
        }
        else
        {
            src.clip = src1;
            src.Play();
        }


        isPlaying = !isPlaying;
    }
}