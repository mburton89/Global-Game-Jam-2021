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
    public AudioSource StickInWall;
    public AudioSource ChaCHING;
    public AudioSource EraserPoof;
    public AudioSource WaterSplode;
    public AudioSource Splode;
    public AudioSource Sunglasses;
    public AudioSource Keys;
    public AudioSource Mug;

    public AudioSource Music;

    private void Awake()
    {
        Instance = this;
    }
}
