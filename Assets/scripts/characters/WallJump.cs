using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : wallreaction
{

public bool isTouchingWall = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (iscorrectground(collision)) {
        isTouchingWall = true;
        }
        Debug.Log("touching wall");


        

        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (iscorrectground(collision)) {
        isTouchingWall = false;
        }
        Debug.Log("not touching wall");


    }

}
