using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarSplode : MonoBehaviour
{
    public List<Rigidbody2D> dollarPrefabs;

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

        Destroy(gameObject, 2);
    }
}
