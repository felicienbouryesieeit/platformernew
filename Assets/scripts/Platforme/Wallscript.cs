using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private BoxCollider2D solidCollider;

    void Start()
    {
        solidCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<projectilescrpar>() != null)
        {
            Destroy(solidCollider);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
