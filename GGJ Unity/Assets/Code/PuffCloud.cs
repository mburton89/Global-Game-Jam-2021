using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PuffCloud : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().DOFade(0, 2);       
    }
}
