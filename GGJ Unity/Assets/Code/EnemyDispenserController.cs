using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDispenserController : MonoBehaviour 
{
    public static EnemyDispenserController Instance;

    [SerializeField] private EnemyDispenser topLeftDispenser;
    [SerializeField] private EnemyDispenser topRightDispenser;
    [SerializeField] private EnemyDispenser bottomLeftDispenser;
    [SerializeField] private EnemyDispenser bottomLeft2Dispenser;
    [SerializeField] private EnemyDispenser bottomRightDispenser;
    [SerializeField] private EnemyDispenser bottomRight2Dispenser;

    public float speed;

    [HideInInspector] public List<Enemy> activeEnemies;

    void Awake () 
    {
        Instance = this;

		topLeftDispenser.Init(this);
		bottomLeft2Dispenser.Init(this);
		topRightDispenser.Init(this);
		bottomRight2Dispenser.Init(this);
        bottomLeftDispenser.Init(this);
        bottomRightDispenser.Init(this);
    }

    private void Start()
    {
        DetermineIfShouldFire();
    }

    void DetermineIfShouldFire()
    {
        if(activeEnemies.Count <= 0)
        {
            FireRandomSequence();
        }
    }

    void FireRandomSequence()
    {
		var randomInt = Random.Range (0, 5);

		if (randomInt == 0)
		{
			FireFour();
		}
		else if (randomInt == 1)
		{
			FireTwoLeft();
		}
		else if (randomInt == 2)
		{
			FireTwoRight();
		}
		else if (randomInt == 3)
		{
			FireMix1();
		}
		else if (randomInt == 4)
		{
			FireMix2();
		}
    }

    public void FireFour()
    {
        activeEnemies.Add(topLeftDispenser.FireEnemy());
        activeEnemies.Add(topRightDispenser.FireEnemy());
        activeEnemies.Add(bottomLeftDispenser.FireEnemy());
        activeEnemies.Add(bottomRightDispenser.FireEnemy());
    }

	public void FireTwoLeft()
	{
        activeEnemies.Add(topLeftDispenser.FireEnemy());
        activeEnemies.Add(bottomLeft2Dispenser.FireEnemy());
	}

	public void FireTwoRight()
	{
        activeEnemies.Add(topRightDispenser.FireEnemy());
        activeEnemies.Add(bottomRight2Dispenser.FireEnemy());
	}

	public void FireMix1()
	{
		activeEnemies.Add(bottomLeft2Dispenser.FireEnemy());
		activeEnemies.Add(topRightDispenser.FireEnemy());
	}

	public void FireMix2()
	{
		activeEnemies.Add(bottomRight2Dispenser.FireEnemy());
		activeEnemies.Add(topLeftDispenser.FireEnemy());
	}

    public void HandleEnemyDestroyed(Enemy destroyedEnemy)
    {
        StartCoroutine(HandleEnemyDestoyedCo(destroyedEnemy));
    }

    private IEnumerator HandleEnemyDestoyedCo(Enemy destroyedEnemy)
    {
        yield return new WaitForSeconds(2);
        activeEnemies.Remove(destroyedEnemy);
        Destroy(destroyedEnemy.gameObject);
        DetermineIfShouldFire();
    }
}
