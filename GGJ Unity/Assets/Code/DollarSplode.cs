using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarSplode : MonoBehaviour
{
    public List<Rigidbody2D> dollarPrefabs;
    public Collider2D collider;

    void Start()
    {
        foreach (Rigidbody2D dollarPrefab in dollarPrefabs)
        {
            Rigidbody2D newDollar = Instantiate(dollarPrefab, transform.position, transform.rotation, this.transform);

            float randX = Random.Range(-250, 280);
            float randY = Random.Range(-250, 280);
            float randZ = Random.Range(-1500, 1500);

            newDollar.AddForce(new Vector2(randX, randY));
            newDollar.AddTorque(randZ);
        }

        Destroy(collider, .12f);
        Destroy(gameObject, 2);
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
