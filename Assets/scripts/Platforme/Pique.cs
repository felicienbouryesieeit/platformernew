using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {   
        

        playerbehavior playerbehaviorvar = other.GetComponent<playerbehavior>();
        if (playerbehaviorvar!= null)
        {
            playerbehaviorvar.charactervar.takedamage(1);
        }
    }
}
