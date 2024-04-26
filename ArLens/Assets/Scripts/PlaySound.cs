using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour, ISoundObject
{
    public AudioSource audioSource;
    public void Play()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
            Debug.Log("playSound");
        }
    }
}
