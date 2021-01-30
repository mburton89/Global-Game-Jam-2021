using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public CircleCollider2D collider;
    public float mass;
    public float damageToGive;
    public int uses;
    public bool canImpale;
    private bool _canGiveDamage;

    public Sprite destroyedSprite;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        if (canImpale)
        {
            collider.isTrigger = true;
        }
        _canGiveDamage = true;
        rigidbody2D.mass = mass;
    }

    //Make it so things that impale can still give damage after they hit something

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            if (_canGiveDamage)
            {
                zombie.TakeDamage(damageToGive);
                GameSoundManager.Instance.ItemHit.Play();
            }
            DecrementUses();

            if (destroyedSprite != null)
            {
                spriteRenderer.sprite = destroyedSprite;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            if (_canGiveDamage)
            {
                zombie.TakeDamage(damageToGive);
                GameSoundManager.Instance.ItemHit.Play();
            }
            DecrementUses();

            if (destroyedSprite != null)
            {
                spriteRenderer.sprite = destroyedSprite;
            }
        }
    }

    void DecrementUses()
    {
        if (!canImpale)
        {
            _canGiveDamage = false;
        }
        uses--;
        if (uses <= 0)
        {
            Destroy(gameObject);
        }
    }
}
