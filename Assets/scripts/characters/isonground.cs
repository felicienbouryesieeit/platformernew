using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isonground : wallreaction
{
public bool isongroundbool;
private characterscr charactervar;




public void beginisonground(characterscr charactervar2) {
charactervar=charactervar2;





}

void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("isonground");

        
        if (iscorrectground(collision)) {
        isongroundbool=true;
        charactervar.canjump=charactervar.canjumpmax;
        //
        //capsuleCollidervar.
        
         }

        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (iscorrectground(collision)) {
        isongroundbool=false;
        charactervar.canjump-=1;
        //collidervar.sharedMaterial = slipvar;
        }
    }

    
}


