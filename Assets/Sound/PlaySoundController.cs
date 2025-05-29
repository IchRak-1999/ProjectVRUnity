using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private bool autoPlay;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        if (autoPlay && CanPlay)
        {
            PlayRandomMusic();
        }
    }

    public void PlayRandomMusic()
    {
        if (!CanPlay) return;

        AudioClip clip = GetRandomMusic();
        source.clip = clip;
        source.Play();
    }

    private AudioClip GetRandomMusic()
    {
        int index = UnityEngine.Random.Range(0, clips.Length);
        return clips[index];
    }

    private bool CanPlay
    {
        get
        {
            bool result = clips != null && clips.Length > 0;

            if (!result)
            {
                UnityEngine.Debug.LogError("There are no clips assigned.");
            }

            return result;
        }
    }
}
