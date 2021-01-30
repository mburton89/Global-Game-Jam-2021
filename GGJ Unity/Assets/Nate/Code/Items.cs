using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [HideInInspector] public float Weight;
    [HideInInspector] public int Durability;
    [HideInInspector] public bool IsReusable;

    public enum ItemType
    {
        WaterBottle,
        Wallet,
        Pencil,
        Sunglasses,
        Phone,
        Umbrella,
        ID,
        Keys,
        Apple,
        Eraser,
        Mug,
        Books,
        Globe,
        TeddyBear,
        Plant,
        Chemicals,
        Thermos,
        Calculator,
        Child,
    }
    public ItemType itemType;

    private void Awake()
    {
        if (itemType == ItemType.WaterBottle)
        {
            Weight = 1.0f;
            Durability = 1;
            IsReusable = false;
        }
        else if (itemType == ItemType.Wallet)
        {
            Weight = 2.0f;
            Durability = 1;
            IsReusable = false;
        }
        else if (itemType == ItemType.Pencil)
        {
            Weight = 1.5f;
            Durability = 3;
            IsReusable = true;
        }
        else if (itemType == ItemType.Sunglasses)
        {
            Weight = .3f;
            Durability = 1;
            IsReusable = false;
        }
        else if (itemType == ItemType.Phone)
        {
            Weight = .5f;
            Durability = 2;
            IsReusable = true;
        }
        else if (itemType == ItemType.Umbrella)
        {
            Weight = 2f;
            Durability = 1;
            IsReusable = false;
        }
        else if (itemType == ItemType.ID)
        {
            Weight = .1f;
            Durability = 1;
            IsReusable = false;
        }
        else if (itemType == ItemType.Keys)
        {
            Weight = .2f;
            Durability = 4;
            IsReusable = true;
        }
        else if (itemType == ItemType.Apple)
        {
            Weight = 1.1f;
            Durability = 1;
            IsReusable = false;
        }
        else if (itemType == ItemType.Eraser)
        {
            Weight = .001f;
            Durability = 1;
            IsReusable = false;
        }
        else if (itemType == ItemType.Mug)
        {
            Weight = .7f;
            Durability = 1;
            IsReusable = false;
        }
        else if (itemType == ItemType.Books)
        {
            Weight = 2.5f;
            Durability = 3;
            IsReusable = true;
        }
        else if (itemType == ItemType.Globe)
        {
            Weight = 1.5f;
            Durability = 2;
            IsReusable = true;
        }
        else if (itemType == ItemType.TeddyBear)
        {
            Weight = .001f;
            Durability = 100;
            IsReusable = true;
        }
        else if (itemType == ItemType.Plant)
        {
            Weight = 1f;
            Durability = 1;
            IsReusable = false;
        }
        else if (itemType == ItemType.Chemicals)
        {
            Weight = 1.5f;
            Durability = 1;
            IsReusable = false;
        }
        else if (itemType == ItemType.Thermos)
        {
            Weight = 1.7f;
            Durability = 5;
            IsReusable = true;
        }
        else if (itemType == ItemType.Calculator)
        {
            Weight = .4f;
            Durability = 2;
            IsReusable = true;
        }
        else if (itemType == ItemType.Child)
        {
            Weight = 3.0f;
            Durability = 1;
            IsReusable = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>())
        {
            AmmoManager.Instance.ammoItems.Add(this);
            //AmmoManager.Instance.AddItem(this);
            Destroy(gameObject);
        }


    }



}
