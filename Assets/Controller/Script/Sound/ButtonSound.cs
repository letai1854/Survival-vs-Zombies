using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip click;
    public static ButtonSound instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Update()
    {
        musicSource.volume = ManagerSenece.instance.volumeValue;
    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.volume = ManagerSenece.instance.volumeValue;
        musicSource.Play();
    }
    public void PlaySFX()
    {
        sfxSource.PlayOneShot(click);
    }
}
