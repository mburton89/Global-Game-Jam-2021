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

    private int _zombiesHit;
    //public DollarSplode dollarSplodePrefab;

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
        _zombiesHit = 0;
    }

    private void Update()
    {
        if (rigidbody2D != null)
        {
            if (ammoType == AmmoType.ID)
            {
                rigidbody2D.AddTorque(38);
            }
            if (_canGiveDamage)
            {
                rigidbody2D.AddForce(new Vector2(windResistance, 0));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            if (_canGiveDamage)
            {
                zombie.TakeDamage(damageToGive);
                PlayHitSoundAndExplode();
                _zombiesHit++;
            }
            DecrementUses();

            if (destroyedSprite != null)
            {
                spriteRenderer.sprite = destroyedSprite;
            }
        }

        if (collision.gameObject.tag == "wall")
        {
            if (canImpale)
            {
                Destroy(rigidbody2D);
                _canGiveDamage = false;
                GameSoundManager.Instance.StickInWall.Play();
            }
        }

        if (_zombiesHit == 2)
        {
            ReportCard.Instance.ShowDoubleKill();
        }
        else if (_zombiesHit == 3)
        {
            ReportCard.Instance.ShowTripleKill();
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
                PlayHitSoundAndExplode();
            }
            DecrementUses();

            if (destroyedSprite != null)
            {
                spriteRenderer.sprite = destroyedSprite;
            }

        }

        if (collision.gameObject.tag == "wall")
        {
            _canGiveDamage = false;
        }

        rigidbody2D.drag = rigidbody2D.drag * 30;
        rigidbody2D.angularDrag = rigidbody2D.angularDrag * 30;
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

    void PlayHitSoundAndExplode()
    {
        if (ammoType == AmmoType.WaterBottle || ammoType == AmmoType.Thermus)
        {
            GameSoundManager.Instance.WaterSplode.Play();
            Instantiate(Resources.Load("Water2") as GameObject, transform.position, transform.rotation, null);
            ReportCard.Instance.ShowWaterSplode();
        }
        else if (ammoType == AmmoType.Wallet)
        {
            GameSoundManager.Instance.ChaCHING.Play();
            //Instantiate(Resources.Load("MoneyExplosion") as GameObject, transform.position, transform.rotation, null);
            DollarSplode dollarSplode = Instantiate(Resources.Load("DollarSplode"), transform.position, transform.rotation, null) as DollarSplode;
            //Destroy(dollarSplode.gameObject, 3);
            ReportCard.Instance.ShowChaching();
        }
        else if (ammoType == AmmoType.Eraser)
        {
            GameSoundManager.Instance.EraserPoof.Play();
            ReportCard.Instance.Lol();
        }
        else
        {
            GameSoundManager.Instance.ItemHit.Play();
        }
    }
}
