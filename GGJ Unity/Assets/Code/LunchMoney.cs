using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchMoney : MonoBehaviour
{
    public List<GameObject> coinPrefabs;
    public float randomness;

    void Start()
    {
        foreach (GameObject coin in coinPrefabs)
        {
            GameObject newCoin = Instantiate(coin, transform.position, transform.rotation, null);
            float randX = Random.Range(-randomness, randomness);
            float randY = Random.Range(-randomness/5f, randomness/5f);
            newCoin.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + randX, GetComponent<Rigidbody2D>().velocity.y + randY);
            //coin.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
            //newCoin.GetComponent<Rigidbody2D>().velocity = new Vector2(randX, 19);
            Destroy(newCoin, 2.5f);
        }
    }
}
