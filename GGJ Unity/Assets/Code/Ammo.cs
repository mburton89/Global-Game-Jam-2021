using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private SlingShotManager _slingShotManager;
    public Rigidbody2D rigidbody2D;
    public CircleCollider2D collider;
    public float mass;
    public float damageToGive;
    public int bounces;
    public bool canImpale;
    private bool _canGiveDamage;
    public float windResistance;
    public float timeToLive;

    public Sprite sketch;
    public Sprite destroyedSprite;
    public SpriteRenderer spriteRenderer;

    public AudioClip hitSound;

    private int _zombiesHit;
    private bool _hasHitZombie;

    bool hasDoubleKilled;
    bool hasTripleKilled;
    bool hasQuadroupleKilled;

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
        Scissors,
        Dodgeball,
        FidgetSpinner,
        RubberChicken,
        StickySoda,
        FoamSword,
        EarBuds,
        LunchMoney,
        Apple,
        LuckyEraser,
        PhatWallet,
        PackOfPencils,
        SuperDodgeball
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
            rigidbody2D.AddTorque(Random.Range(5, 14));
        }
        _canGiveDamage = true;
        rigidbody2D.mass = mass;
        float windMultiplier = windResistance * 40;
        windResistance = Random.Range(-windMultiplier, windMultiplier);
        _zombiesHit = 0;
        PostWaveMenu.Instance.itemsShot++;
        _slingShotManager = FindObjectOfType<SlingShotManager>();
    }

    private void Update()
    {
        if (rigidbody2D != null)
        {
            if (ammoType == AmmoType.ID)
            {
                rigidbody2D.AddTorque(38);
            }
            if (_canGiveDamage && PlayerPrefs.GetInt("Hitstreak100") != 1)
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
                HitStreakManager.Instance.AddToCurrentHitStreak();
                _hasHitZombie = true;
                PlayHitSoundAndExplode();
                _zombiesHit++;

                if (_zombiesHit == 1)
                {
                    PostWaveMenu.Instance.itemsHit++;
                }
                else if (_zombiesHit > 1)
                {
                    PostWaveMenu.Instance.multiKills++;
                }

                if (ammoType == AmmoType.Glasses)
                {
                    zombie.WearSunglasses();
                    Destroy(gameObject);
                }
            }

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
                GameSoundManager.Instance.StickInWall.Play();
            }
            if (ammoType != AmmoType.Dodgeball && ammoType != AmmoType.FidgetSpinner)
            {
                Destroy(collider, 0.5f);
                _canGiveDamage = false;
            }
            if (!_hasHitZombie && Timer.Instance.timeLeft > 0 && ammoType != AmmoType.Pencil && ammoType != AmmoType.LunchMoney && ammoType != AmmoType.FidgetSpinner && ammoType != AmmoType.Dodgeball)
            {
                HitStreakManager.Instance.Reset();
            }
        }

        if (_zombiesHit == 2 && !hasDoubleKilled)
        {
            ReportCard.Instance.ShowDoubleKill();
            hasDoubleKilled = true;
        }
        else if (_zombiesHit == 3 && !hasTripleKilled)
        {
            ReportCard.Instance.ShowTripleKill();
            hasTripleKilled = true;

            if (ammoType == AmmoType.Pencil)
            {
                AssignmentsManager.Instance.CompleteTripleSharpKillAssignment();
            }
        }
        else if (_zombiesHit == 4 && !hasQuadroupleKilled)
        {
            ReportCard.Instance.ShowQuadroupleKill();
            hasQuadroupleKilled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            if (_canGiveDamage)
            {
                zombie.TakeDamage(damageToGive, ammoType);
                HitStreakManager.Instance.AddToCurrentHitStreak();
                _hasHitZombie = true;
                PlayHitSoundAndExplode();
                PostWaveMenu.Instance.itemsHit++;
                _zombiesHit++;
                if (ammoType == AmmoType.Glasses)
                {
                    zombie.WearSunglasses();
                    Destroy(gameObject);
                }                
            }

            if (destroyedSprite != null)
            {
                spriteRenderer.sprite = destroyedSprite;
            }

            if (ammoType == AmmoType.StickySoda)
            {
                Destroy(rigidbody2D);
                transform.SetParent(collision.transform);
                transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + .5f, 0);
            }
        }

        if (collision.gameObject.tag == "wall")
        {
            if (!_hasHitZombie && Timer.Instance.timeLeft > 0 && ammoType != AmmoType.Pencil && ammoType != AmmoType.LunchMoney && ammoType != AmmoType.FidgetSpinner && ammoType != AmmoType.Dodgeball)
            {
                HitStreakManager.Instance.Reset();
            }
        }

        if (_zombiesHit == 2 && !hasDoubleKilled)
        {
            ReportCard.Instance.ShowDoubleKill();
            hasDoubleKilled = true;
        }
        else if (_zombiesHit == 3 && !hasTripleKilled)
        {
            ReportCard.Instance.ShowTripleKill();
            hasTripleKilled = true;
        }
        else if (_zombiesHit == 4 && !hasQuadroupleKilled)
        {
            ReportCard.Instance.ShowQuadroupleKill();
            hasQuadroupleKilled = true;

            if (ammoType == AmmoType.Dodgeball)
            {
                AssignmentsManager.Instance.CompleteQuadroupleDodgeballKillAssignment();
            }
        }

        bounces--;
        if (bounces < 1)
        {
            spriteRenderer.sortingOrder = -2;
            rigidbody2D.drag = rigidbody2D.drag = 5;
            rigidbody2D.angularDrag = rigidbody2D.angularDrag = 5;
            Destroy(collider, 0.25f);
            if (!canImpale)
            {
                _canGiveDamage = false;
            }
        }

        if (ammoType == AmmoType.FidgetSpinner)
        {
            GetComponent<AudioSource>().Play();
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddTorque(80f);
            rigidbody2D.drag = rigidbody2D.drag = 0.2f;
            rigidbody2D.angularDrag = rigidbody2D.angularDrag = 0.2f;
            if (bounces == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void PlayHitSoundAndExplode()
    {
        if (hitSound != null)
        {
            GameSoundManager.Instance.PlayHitSound(hitSound);
        }
        else
        {
            Debug.LogWarning("Repace Ammo with new sound logic");
        }

        if (ammoType == AmmoType.WaterBottle || ammoType == AmmoType.Thermus)
        {
            Instantiate(Resources.Load("Water2") as GameObject, transform.position, transform.rotation, null);
            ReportCard.Instance.ShowWaterSplode();
        }
        else if (ammoType == AmmoType.Wallet)
        {
            //Instantiate(Resources.Load("MoneyExplosion") as GameObject, transform.position, transform.rotation, null);
            DollarSplode dollarSplode = Instantiate(Resources.Load("DollarSplode"), transform.position, transform.rotation, null) as DollarSplode;
            //Destroy(dollarSplode.gameObject, 3);
            ReportCard.Instance.ShowChaching();
        }
        else if (ammoType == AmmoType.PhatWallet)
        {
            //Instantiate(Resources.Load("MoneyExplosion") as GameObject, transform.position, transform.rotation, null);
            DollarSplode dollarSplode = Instantiate(Resources.Load("DollarSplode"), transform.position, transform.rotation, null) as DollarSplode;
            //Destroy(dollarSplode.gameObject, 3);
            ReportCard.Instance.ShowChaching();
            GetComponent<LunchMoney>().enabled = true;
        }
        else if (ammoType == AmmoType.Eraser)
        {
            DollarSplode dollarSplode = Instantiate(Resources.Load("PuffSplode"), transform.position, transform.rotation, null) as DollarSplode;
            ReportCard.Instance.Lol();
        }
        else if (ammoType == AmmoType.LuckyEraser)
        {
            DollarSplode dollarSplode = Instantiate(Resources.Load("PuffSplode"), transform.position, transform.rotation, null) as DollarSplode;
            ReportCard.Instance.Lol();
            //int rand = Random.Range(0, 1);
            //if (rand == 0)
            //{
                Zombie[] zombies = FindObjectsOfType<Zombie>();
                if (zombies == null) return;
                foreach (Zombie zombie in zombies)
                {
                    zombie.Splode();
                }
            //}
        }

    }

    private void OnDestroy()
    {
        if (ammoType == AmmoType.StickySoda)
        {
            Instantiate(Resources.Load("Soda") as GameObject, transform.position, transform.rotation, null);
        }
    }
}
