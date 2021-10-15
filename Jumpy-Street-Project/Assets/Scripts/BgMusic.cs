using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMusic : MonoBehaviour
{
    public static BgMusic BgInstance;
    public AudioSource Audio;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void Stop()
    {
        Audio = GetComponent<AudioSource>();
        Audio.Stop();
    }

    public void Play()
    {
        Audio = GetComponent<AudioSource>();
        Audio.Play();
    }
}
