using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler
{
    public GameObject HoverEffect;
    public bool isStartButton;

    void Awake()
    {
        GetComponent<Image>().color = Color.clear;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isStartButton)
        {
            MainMenu.Instance.Play();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        HoverEffect.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MainMenu.Instance.buttonHover.Play();
        HoverEffect.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (HoverEffect != null)
        {
            HoverEffect.SetActive(false);
        }
    }
}
