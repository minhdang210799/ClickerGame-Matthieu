using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int clip)
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No Audio Source!");
            return;
        }

        audioSource.clip = clips[clip];
        audioSource.Play();
    }
}
