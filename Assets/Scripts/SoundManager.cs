
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioClip checkSound;

    private void PlayHitSound()
    {
        source.PlayOneShot(clip);
    }

    private void OnEnable()
    {
        PlayerEvents.onHitEvent += PlayHitSound;
        PlayerEvents.onFlagHitEvent += PlayCheckSound;
    }

    private void OnDisable()
    {
        PlayerEvents.onHitEvent -= PlayHitSound;
        PlayerEvents.onFlagHitEvent -= PlayCheckSound;
    }
    private void PlayCheckSound()
    {
        if (checkSound != null)
            source.PlayOneShot(checkSound);
    }
}
