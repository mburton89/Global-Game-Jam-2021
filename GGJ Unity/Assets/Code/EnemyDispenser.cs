using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDispenser : MonoBehaviour 
{
    private EnemyDispenserController _controller;
    [SerializeField] Enemy _enemy;
    [SerializeField] private Vector2 directionToDispense;

    public void Init (EnemyDispenserController controller)
    {
        _controller = controller;
    }

    public Enemy FireEnemy()
    {
        Enemy clone = Instantiate(_enemy, transform.position, Quaternion.identity) as Enemy;
        clone.gameObject.SetActive(true);
        clone.Init(directionToDispense, _controller.speed);
        return clone;
    }
}
