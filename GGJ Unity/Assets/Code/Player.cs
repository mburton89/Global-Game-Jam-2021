using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public SpriteRenderer spriteRenderer;
    public Sprite pullBack;
    public Sprite sling;
    public Sprite idle;

    void Awake()
    {
        Instance = this;
    }

    public void ShowPullBackSprite()
    {
        StopCoroutine(nameof(ShowSlingSpriteCo));
        spriteRenderer.sprite = pullBack;
    }
    public void ShowSlingSprite()
    {
        StartCoroutine(nameof(ShowSlingSpriteCo));
    }

    public void ShowIdle()
    {
        spriteRenderer.sprite = idle;
    }

    private IEnumerator ShowSlingSpriteCo()
    {
        spriteRenderer.sprite = sling;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = idle;
    }
}
