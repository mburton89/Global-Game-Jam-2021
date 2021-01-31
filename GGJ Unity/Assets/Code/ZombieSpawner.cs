using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    public Zombie zombiePrefab;
    public float spawnRate;
    public float zombieSpeed;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnCo());
    }

    private IEnumerator SpawnCo()
    {
        yield return new WaitForSeconds(spawnRate);
        Zombie newZombie = Instantiate(zombiePrefab, transform.position, transform.rotation, null);
        newZombie.walkSpeed = zombieSpeed;
        GameSoundManager.Instance.ZombieSpawn.Play();
        StartCoroutine(SpawnCo());
    }
}
