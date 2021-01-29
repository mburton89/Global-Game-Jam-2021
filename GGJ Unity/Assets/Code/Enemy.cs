using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    private bool _isHit = false;

    public void Init(Vector2 direction, float speed)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!_isHit)
        {
            EnemyDispenserController.Instance.HandleEnemyDestroyed(this);
            _isHit = true;
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
