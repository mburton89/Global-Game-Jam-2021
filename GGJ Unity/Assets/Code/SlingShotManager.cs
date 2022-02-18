using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlingShotManager : MonoBehaviour
{
    public GameObject ball;

    public List<Ammo> ammos;
    public Ammo eraserAmmo;
    public Ammo eraserAmmoU;
    public Ammo walletAmmo;
    public Ammo walletAmmoU;
    public Ammo pencilAmmo;
    public Ammo pencilAmmoU;
    public Ammo dodgeballAmmo;
    public Ammo dodgeballAmmoU;

    [SerializeField] MeshRenderer aimLine4a;
    [SerializeField] MeshRenderer aimLine4b;

    private int _ammoIndex = 0;
    public Ammo nextAmmo;

    public Transform leftAnchor;
    public Transform rightAnchor;
    public Transform ObjectHolder;
    public Transform aimer;
    public LineRenderer[] lines;
    public static SlingShotManager instance;
    public GameObject[] points;
    public float speed;

    public int ammosRemaining;
    public TextMeshProUGUI _ammoRemaining;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("Wave") == 1)
        {
            PlayerPrefs.SetInt("ItemsRemaining", 20);
        }
        //ammosRemaining = 36 + (PlayerPrefs.GetInt("Wave") * 2);
        //ammosRemaining = PlayerPrefs.GetInt("ItemsRemaining") + 10;
        ammosRemaining = 20;
        _ammoRemaining.SetText(ammosRemaining.ToString());
        lines[0].SetPosition(0, leftAnchor.position);
        lines[1].SetPosition(0, rightAnchor.position);
        setPath(true);

        _ammoIndex = 0;
        //RandomizeOrder();
        DetermineUnlockables();
        DetermineNextAmmo();

        if (PlayerPrefs.GetInt("Wave10Assignment") == 1)
        {
            speed = speed + (speed * .2f);
        }

        if (PlayerPrefs.GetInt("Wave20Assignment") == 1)
        {
            speed = speed + (speed * .2f);
        }
    }

    void Update()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].SetPosition(1, ObjectHolder.position);
        }
    }

    public void setPath(bool b)
    {
        float yPos = ((aimer.up.y * 1.5f) / points.Length);
        float val = yPos;
        for (int i = 0; i < points.Length; i++)
        {
            points[i].SetActive(b);
            points[i].transform.parent = aimer;
            points[i].transform.localPosition = new Vector3(0, val, -0.8f);
            val += yPos;
        }
    }

    public void SlingAmmo()
    {
        if (ammosRemaining <= 0)
        {
            return;
        }

        GameSoundManager.Instance.SlingRelease.Play();
        //randomizer
        //_ammoIndex = Random.Range(0, ammos.Count);

        //Ammo currentAmmo = Ammo currentAmmo = ammos[_ammoIndex];

        ObjectHolder.GetComponent<Collider2D>().enabled = false;
        //GameObject clone = Instantiate(ball, ball.transform.position, Quaternion.identity) as GameObject;
        Ammo clone = Instantiate(nextAmmo, nextAmmo.transform.position, Quaternion.identity) as Ammo;
        clone.GetComponent<Rigidbody2D>().AddForce(aimer.up * speed, ForceMode2D.Impulse);
        //clone.transform.eulerAngles = aimer.up;
        //print(aimer.up);

        if (aimer.up.x < -0.3)
        {
            clone.transform.eulerAngles = new Vector3(0, 0, 22);
        }
        else if(aimer.up.x > 0.3)
        {
            clone.transform.eulerAngles = new Vector3(0, 0, -22);
        }
        Destroy(clone.gameObject, clone.timeToLive);

        //_ammoIndex++;
        DetermineNextAmmo();

        Player.Instance.ShowSlingSprite();

        ammosRemaining --;
        _ammoRemaining.SetText(ammosRemaining.ToString());

        if (ammosRemaining < 1)
        {
            CurrentAmmoNote.Instance.UpdateUI(null);
        }
    }

    void DetermineNextAmmo()
    {
        _ammoIndex = Random.Range(0, ammos.Count);
        nextAmmo = ammos[_ammoIndex];
        CurrentAmmoNote.Instance.UpdateUI(nextAmmo.sketch);
        if (ammos.Count > 1)
        {
            ammos.RemoveAt(_ammoIndex);
        }
    }

    void DetermineUnlockables()
    {
        if (PlayerPrefs.GetInt("SingleEraserAssignment") == 1)
        {
            ammos[0] = eraserAmmoU;
        }
        if (PlayerPrefs.GetInt("DoubleSplodeAssignment") == 1)
        {
            ammos[1] = walletAmmoU;
        }
        if (PlayerPrefs.GetInt("TripleSharpAssignment") == 1)
        {
            ammos[2] = pencilAmmoU;
        }
        if (PlayerPrefs.GetInt("QuadroupleDodgeballAssignment") == 1)
        {
            ammos[3] = dodgeballAmmoU;
        }
        if (PlayerPrefs.GetInt("Hitstreak50") == 1)
        {
            aimLine4a.enabled = true;
            aimLine4b.enabled = true;
        }
        //if (PlayerPrefs.GetInt("Hitstreak100") == 1)
        //{
            
        //}
        if (PlayerPrefs.GetInt("Wave10Assignment") == 1)
        {
            speed = 23f;
        }
        if (PlayerPrefs.GetInt("Wave20Assignment") == 1)
        {
            speed = 29f;
        }
    }
    //void DetermineNextAmmo()
    //{
    //    _ammoIndex ++;
    //    nextAmmo = ammos[_ammoIndex];
    //    CurrentAmmoNote.Instance.UpdateUI(nextAmmo.sketch);
    //}
}