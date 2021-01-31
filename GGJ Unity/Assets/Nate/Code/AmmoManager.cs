using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager Instance;
    public List<Items> ammoItems;

    private void Awake()
    {
        Instance = this;
        ammoItems = new List<Items>();
    }

    public void AddItem(Items item)
    {
        print(" ");
    }
}
