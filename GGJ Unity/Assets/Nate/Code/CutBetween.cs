using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutBetween : MonoBehaviour
{
    private Character _target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.GetComponent<Character>())
        {
            _target = collision.GetComponent<Character>();
            _target.movementSpeed = _target.movementSpeed / 4;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>())
        {
            _target.movementSpeed = _target.movementSpeed * 4;
        }
    }
}
