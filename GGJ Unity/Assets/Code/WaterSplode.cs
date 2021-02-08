using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplode : MonoBehaviour
{
    public Collider2D collider;

    void Start()
    {
        Destroy(collider, .12f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            zombie.TakeDamage(2);
            HitStreakManager.Instance.AddToCurrentHitStreak();
        }
    }
}
