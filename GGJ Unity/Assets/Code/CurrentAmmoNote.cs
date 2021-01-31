using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentAmmoNote : MonoBehaviour
{
    public static CurrentAmmoNote Instance;

    public Sprite waterBottle;
    public Sprite wallet;
    public Sprite pencil;
    public Sprite phone;
    public Sprite glasses;
    public Sprite unbrella;
    public Sprite ID;
    public Sprite Keys;
    public Sprite Eraser;
    public Sprite Mug;
    public Sprite Child;
    public Sprite Globe;
    public Sprite Book;
    public Sprite Plant;
    public Sprite Thermus;
    public Sprite Calculator;
    public Sprite Knife;
    public Sprite Scissors;
    public Image currentItemSprite; 

    private void Awake()
    {
        Instance = this;    
    }
    public void UpdateUI(Ammo.AmmoType ammoType)
    {
        if (ammoType == Ammo.AmmoType.WaterBottle)
        {
            currentItemSprite.sprite = waterBottle;
        }
        else if (ammoType == Ammo.AmmoType.Wallet)
        {
            currentItemSprite.sprite = wallet;
        }
        else if (ammoType == Ammo.AmmoType.Pencil)
        {
            currentItemSprite.sprite = pencil;
        }
        else if (ammoType == Ammo.AmmoType.Phone)
        {
            currentItemSprite.sprite = phone;
        }
        else if (ammoType == Ammo.AmmoType.Glasses)
        {
            currentItemSprite.sprite = glasses;
        }
        else if (ammoType == Ammo.AmmoType.Umbrella)
        {
            currentItemSprite.sprite = unbrella;
        }
        else if (ammoType == Ammo.AmmoType.ID)
        {
            currentItemSprite.sprite = ID;
        }
        else if (ammoType == Ammo.AmmoType.Keys)
        {
            currentItemSprite.sprite = Keys;
        }
        else if (ammoType == Ammo.AmmoType.Eraser)
        {
            currentItemSprite.sprite = Mug;
        }
        else if (ammoType == Ammo.AmmoType.Child)
        {
            currentItemSprite.sprite = Child;
        }
        else if (ammoType == Ammo.AmmoType.Globe)
        {
            currentItemSprite.sprite = Globe;
        }
        else if (ammoType == Ammo.AmmoType.Book)
        {
            currentItemSprite.sprite = Book;
        }
        else if (ammoType == Ammo.AmmoType.Plant)
        {
            currentItemSprite.sprite = Plant;
        }
        else if (ammoType == Ammo.AmmoType.Thermus)
        {
            currentItemSprite.sprite = Thermus;
        }
        else if (ammoType == Ammo.AmmoType.Calculator)
        {
            currentItemSprite.sprite = Calculator;
        }
        else if (ammoType == Ammo.AmmoType.Knife)
        {
            currentItemSprite.sprite = Knife;
        }
        else if (ammoType == Ammo.AmmoType.Scissors)
        {
            currentItemSprite.sprite = Scissors;
        }
    }
}
