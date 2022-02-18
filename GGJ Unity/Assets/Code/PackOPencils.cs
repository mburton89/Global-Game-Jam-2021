using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackOPencils : MonoBehaviour
{
    [SerializeField] GameObject pencilPrefab;
    [SerializeField] float xRange;

    void Start()
    {

        GameObject pencil1 = Instantiate(pencilPrefab, transform.position, transform.rotation, null);
        pencil1.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + xRange, GetComponent<Rigidbody2D>().velocity.y);

        GameObject pencil2 = Instantiate(pencilPrefab, transform.position, transform.rotation, null);
        pencil1.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - xRange, GetComponent<Rigidbody2D>().velocity.y);
    }
}
