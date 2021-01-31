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
    public float windResistance;

    public Sprite destroyedSprite;
    public SpriteRenderer spriteRenderer;

    public enum AmmoType
    {
        WaterBottle,
        Wallet,
        Pencil,
        Phone,
        Glasses,
        Umbrella,
        ID,
        Keys,
        Eraser,
        Mug,
        Child,
        Globe,
        Book,
        Plant,
        Thermus,
        Calculator,
        Knife,
        Scissors
    }

    public AmmoType ammoType;

    void Start()
    {
        if (canImpale)
        {
            collider.isTrigger = true;

        }
        else
        {
            rigidbody2D.AddTorque(Random.Range(4, 12));
        }
        _canGiveDamage = true;
        rigidbody2D.mass = mass;
        float windMultiplier = windResistance * 40;
        windResistance = Random.Range(-windMultiplier, windMultiplier);
    }

   // Vector3 previousPos = new Vector3();
    private void Update()
    {
        if (ammoType == AmmoType.ID)
        {
            rigidbody2D.AddTorque(38);
        }
        if (_canGiveDamage)
        {
            rigidbody2D.AddForce(new Vector2(windResistance, 0));
        }
        //transform.rotation = Quaternion.LookRotation(new Vector3(0 ,0, rigidbody2D.velocity.x));
        //Vector3 relativePos = previousPos - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
        //transform.rotation = rotation;
        //previousPos = transform.position;
    }

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
