using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject HoverEffect;
    public bool isStartButton;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isStartButton)
        {
            MainMenu.Instance.Play();
        }
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
