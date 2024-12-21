using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip gun;
    public AudioClip sword;
    public AudioClip dash;
    public AudioClip energy;
    public AudioClip zombieBite;
    public AudioClip item;
    public AudioClip victory;
    public AudioClip lose;
    private void Start()
    {
        musicSource.clip = background;
        musicSource.volume = ManagerSenece.instance.volumeValue;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip);
    }
}
