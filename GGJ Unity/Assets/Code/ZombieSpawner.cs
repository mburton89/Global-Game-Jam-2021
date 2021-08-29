using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    public List<Zombie> zombiePrefabs;
    public float spawnRate;
    public float zombieSpeed;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(nameof(SpawnCo));
        zombieSpeed = zombieSpeed + (PlayerPrefs.GetInt("Wave")/3);
    }

    public void EndWave()
    {
        spawnRate = 10000;
        zombieSpeed = 0;
        StopCoroutine(nameof(SpawnCo));
    }

    private IEnumerator SpawnCo()
    {
        int rand = Random.Range(0, 2);
        Zombie zombieToSpawn = zombiePrefabs[rand];
        yield return new WaitForSeconds(spawnRate);
        Zombie newZombie = Instantiate(zombieToSpawn, transform.position, transform.rotation, null);
        newZombie.walkSpeed = zombieSpeed;
        GameSoundManager.Instance.ZombieSpawn.Play();
        StartCoroutine(SpawnCo());
    }
}
