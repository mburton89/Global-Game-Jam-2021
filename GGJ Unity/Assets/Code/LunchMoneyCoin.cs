using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchMoneyCoin : MonoBehaviour
{

    //private void Start()
    //{
    //    Destroy(gameObject, 2.5f);
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<Zombie>() || collision.gameObject.tag == "Wall")
    //    {
    //        GetComponent<Collider2D>().isTrigger = false;
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
}
