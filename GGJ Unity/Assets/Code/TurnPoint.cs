using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPoint : MonoBehaviour
{
    public int xDir;
    public int yDir;

    private void Start()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
}
