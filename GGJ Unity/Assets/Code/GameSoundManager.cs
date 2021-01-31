using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    public static GameSoundManager Instance;

    public AudioSource SlingPull;
    public AudioSource SlingRelease;
    public AudioSource ItemHit;
    public AudioSource Chaching;
    public AudioSource ItemImpale;
    public AudioSource ZombieSpawn;
    public AudioSource ZombieSplode;
    public AudioSource SchoolBell;

    private void Awake()
    {
        Instance = this;
    }
}
