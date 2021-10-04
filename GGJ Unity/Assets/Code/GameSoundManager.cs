using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    public static GameSoundManager Instance;

    public AudioSource SlingPull;
    public AudioSource SlingRelease;
    public AudioSource StickInWall;
    public AudioSource SchoolBell;
    public AudioSource ZombieSpawn;
    public AudioSource ZombieSplode;
    public AudioSource Splode;
    //public AudioSource ItemHit;
    //public AudioSource Chaching;
    //public AudioSource ItemImpale;
    //public AudioSource ChaCHING;
    //public AudioSource EraserPoof;
    //public AudioSource WaterSplode;
    //public AudioSource Sunglasses;
    //public AudioSource Keys;
    //public AudioSource Mug;
    //public AudioSource DodgeBall;

    public AudioSource Music;

    public List<AudioSource> hitSoundAudioSources;
    AudioSource activeHitSoundAudioSource;
    int index;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        index = 0;
        activeHitSoundAudioSource = hitSoundAudioSources[index];
    }

    public void PlayHitSound(AudioClip audioClip)
    {
        activeHitSoundAudioSource.clip = audioClip;
        activeHitSoundAudioSource.Play();
        if (index >= hitSoundAudioSources.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        activeHitSoundAudioSource = hitSoundAudioSources[index];
    }
}
