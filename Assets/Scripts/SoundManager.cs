using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    public static SoundManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlayRandomAsteroidSound()
    {
        audioSource.clip = audioClips[Random.Range(0, 2)];
        audioSource.Play();
    }
}
