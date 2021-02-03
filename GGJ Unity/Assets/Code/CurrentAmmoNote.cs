using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public TextMeshProUGUI notes;

    private const string WATER_BOTTLE_NOTES = "BOTTLE: Water go SPLODE";
    private const string WALLET_NOTES = "WALLET: Make it rain! Cha CHING SPLODE";
    private const string PENCIL_NOTES = "PENCIL: Pokes thru zombies";
    private const string PHONE_NOTES = "PHONE: Hey, no phones in class";
    private const string GLASSES_NOTES = "Zombies CAN'T SEE!.. But look cool :D";
    private const string UMBRELLA_NOTES = "UMBRELLA: Impales Zombies! ombies! ombies! eh. eh. eh.";
    private const string ID_NOTES = "ID: Slices thru Zombies! Catches Wind!";
    private const string KEYS_NOTES = "KEYS: Slows 'em down";
    private const string ERASER_NOTES = "BOARD ERASER: Pretty much useless";
    private const string MUG_NOTES = "MUG: Go fer a mug shot!";
    private const string CHILD_NOTES = "uhhh, wtf!?";
    private const string GLOBE_NOTES = "GLOBE: Yep";
    private const string BOOK_NOTES = "BOOK: ammo > reading material";
    private const string PLANT_NOTES = "Plant";
    private const string THERMUS_NOTES = "Thermus go SPLODE";
    private const string CALCULATOR_NOTES = "80008135. Slows Zombz down";
    private const string KNIFE_NOTES = "KNIFE: Slices thru zombz!";
    private const string SCISSORS_NOTES = "Cuts thru Zombies";


    private void Awake()
    {
        Instance = this;    
    }
    public void UpdateUI(Ammo.AmmoType ammoType)
    {
        if (ammoType == Ammo.AmmoType.WaterBottle)
        {
            currentItemSprite.sprite = waterBottle;
            notes.SetText(WATER_BOTTLE_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Wallet)
        {
            currentItemSprite.sprite = wallet;
            notes.SetText(WALLET_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Pencil)
        {
            currentItemSprite.sprite = pencil;
            notes.SetText(PENCIL_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Phone)
        {
            currentItemSprite.sprite = phone;
            notes.SetText(PHONE_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Glasses)
        {
            currentItemSprite.sprite = glasses;
            notes.SetText(GLASSES_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Umbrella)
        {
            currentItemSprite.sprite = unbrella;
            notes.SetText(UMBRELLA_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.ID)
        {
            currentItemSprite.sprite = ID;
            notes.SetText(ID_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Keys)
        {
            currentItemSprite.sprite = Keys;
            notes.SetText(KEYS_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Eraser)
        {
            currentItemSprite.sprite = Eraser;
            notes.SetText(ERASER_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Child)
        {
            currentItemSprite.sprite = Child;
            notes.SetText(CHILD_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Globe)
        {
            currentItemSprite.sprite = Globe;
            notes.SetText(GLOBE_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Book)
        {
            currentItemSprite.sprite = Book;
            notes.SetText(BOOK_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Plant)
        {
            currentItemSprite.sprite = Plant;
            notes.SetText(PLANT_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Thermus)
        {
            currentItemSprite.sprite = Thermus;
            notes.SetText(THERMUS_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Calculator)
        {
            currentItemSprite.sprite = Calculator;
            notes.SetText(CALCULATOR_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Knife)
        {
            currentItemSprite.sprite = Knife;
            notes.SetText(KNIFE_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Scissors)
        {
            currentItemSprite.sprite = Scissors;
            notes.SetText(SCISSORS_NOTES);
        }
        else if (ammoType == Ammo.AmmoType.Mug)
        {
            currentItemSprite.sprite = Mug;
            notes.SetText(MUG_NOTES);
        }
    }
}
