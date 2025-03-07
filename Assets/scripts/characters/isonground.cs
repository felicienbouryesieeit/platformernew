using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isonground : wallreaction
{
public bool isongroundbool;
private characterscr charactervar;
private CapsuleCollider2D collidervar;
[SerializeField]
private PhysicsMaterial2D slipvar;
private PhysicsMaterial2D emptymat;

public void beginisonground(characterscr charactervar2) {
charactervar=charactervar2;

collidervar = charactervar.GetComponent<CapsuleCollider2D>();
Debug.Log("material : " + collidervar.sharedMaterial);



}

void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("isonground");

        
        if (iscorrectground(collision)) {
        isongroundbool=true;
        charactervar.canjump=charactervar.canjumpmax;
        //collidervar.sharedMaterial = emptymat;
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


