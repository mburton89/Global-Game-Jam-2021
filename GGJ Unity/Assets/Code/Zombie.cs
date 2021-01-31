using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float walkSpeed;
    public int xDir;
    public int yDir;
    public float initialHealth;
    float currentHealth;
    private Vector3 walkDirection;

    private void Start()
    {
        currentHealth = initialHealth;
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

        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Walk()
    {
        transform.Translate(walkDirection * walkSpeed * Time.deltaTime);
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth = currentHealth - damageToTake;

        if (currentHealth <= 0)
        {
            Splode();
        }
    }

    public void Splode()
    {
        ScoreManager.Instance.AddPoint();
        GameSoundManager.Instance.ZombieSplode.Play();
        GameSoundManager.Instance.Splode.Play();
        Destroy(gameObject);
        Instantiate(Resources.Load("Explosion") as GameObject, transform.position, transform.rotation, null);
        Instantiate(Resources.Load("BloodSplash 1") as GameObject, transform.position, transform.rotation, null);
    }
}
