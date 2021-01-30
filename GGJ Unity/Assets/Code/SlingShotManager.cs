﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotManager : MonoBehaviour
{
    public GameObject ball;

    public List<GameObject> ammos;
    private int _ammoIndex = 0;

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
        float yPos = (aimer.up.y * 2.5f) / points.Length;
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
        _ammoIndex = Random.Range(0, ammos.Count);

        GameObject currentAmmo = ammos[_ammoIndex];

        ObjectHolder.GetComponent<Collider2D>().enabled = false;
        //GameObject clone = Instantiate(ball, ball.transform.position, Quaternion.identity) as GameObject;
        GameObject clone = Instantiate(currentAmmo, currentAmmo.transform.position, Quaternion.identity) as GameObject;
        clone.SetActive(true);
        clone.GetComponent<Rigidbody2D>().AddForce(aimer.up * speed, ForceMode2D.Impulse);
        Destroy(clone, 30f);

        //_ammoIndex++;
    }
}