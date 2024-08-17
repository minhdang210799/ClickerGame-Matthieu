using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public void PlaySound(AudioClip clip)
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        audioSource.clip = clip;
        audioSource.Play();
    }
}
