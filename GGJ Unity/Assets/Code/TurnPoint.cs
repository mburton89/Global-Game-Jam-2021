﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPoint : MonoBehaviour
{
    public int xDir;
    public int yDir;
    public int sunglassesXDir;

    private void Start()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
}
