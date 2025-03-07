using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            characterscr playerScript = other.gameObject.GetComponent<characterscr>();
            if (playerScript != null)
            {
                playerScript.takedamage(damage);
            }
        }
    }
}
