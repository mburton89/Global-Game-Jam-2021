using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bob : MonoBehaviour
{
    public float initialYPosition;
    public float amountToMove;
    public float duration;

    void Start()
    {
        initialYPosition = transform.position.y;
        StartCoroutine(BobCo());
    }

    private IEnumerator BobCo()
    {
        transform.DOMoveY(initialYPosition + amountToMove, duration).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(duration);
        transform.DOMoveY(initialYPosition, duration).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(duration);
        StartCoroutine(BobCo());
    }
}