using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip cubesound;
    [SerializeField] private AudioSource _audioSource;

    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
     }
    
    public void PlayScoreUpdateSfx()
    {
        _audioSource.Play();
    }

    public void StopSound()
    {
        _audioSource.Stop();
    }
}