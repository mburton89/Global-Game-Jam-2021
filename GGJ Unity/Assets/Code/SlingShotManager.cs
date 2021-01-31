using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotManager : MonoBehaviour
{
    public GameObject ball;

    public List<Ammo> ammos;
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

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lines[0].SetPosition(0, leftAnchor.position);
        lines[1].SetPosition(0, rightAnchor.position);
        setPath(true);

        DetermineNextAmmo();
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
        float yPos = (aimer.up.y * 1.1f) / points.Length;
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
        Destroy(clone.gameObject, 2.5f);

        //_ammoIndex++;
        DetermineNextAmmo();

        Player.Instance.ShowSlingSprite();
    }

    void DetermineNextAmmo()
    {
        _ammoIndex = Random.Range(0, ammos.Count);
        nextAmmo = ammos[_ammoIndex];
        CurrentAmmoNote.Instance.UpdateUI(nextAmmo.ammoType);
    }
}