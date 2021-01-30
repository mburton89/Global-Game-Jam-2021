using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float walkSpeed;
    public int xDir;
    public int yDir;
    public float initialHealth;
    public float currentHealth;
    private Vector3 walkDirection;

    private void Start()
    {
        walkDirection = new Vector3(-1, 0, 0);
    }
    private void Update()
    {
        Walk();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TurnPoint>())
        {
            TurnPoint turnPoint = collision.gameObject.GetComponent<TurnPoint>();
            walkDirection = new Vector3(turnPoint.xDir, turnPoint.yDir, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TurnPoint>())
        {
            TurnPoint turnPoint = collision.gameObject.GetComponent<TurnPoint>();
            walkDirection = new Vector3(turnPoint.xDir, turnPoint.yDir, 0);
        }
    }

    public void Walk()
    {
        transform.Translate(walkDirection * walkSpeed * Time.deltaTime);
    }

    public void Splode()
    {

    }
}
