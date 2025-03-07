using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : wallreaction
{

public bool isTouchingWall = false;

//private CapsuleCollider2D collidervar;
private Rigidbody2D collidervar;
[SerializeField]
private characterscr charactervar;

private PhysicsMaterial2D emptymat;

[SerializeField]
private PhysicsMaterial2D slipvar;
    protected override void Start2()
    {
        base.Start2();
        //charactervar= GetComponent<characterscr>();
        collidervar = charactervar.GetComponent<Rigidbody2D>();
        Debug.Log("material : " + collidervar.sharedMaterial);
        emptymat=collidervar.sharedMaterial;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (iscorrectground(collision)) {
        isTouchingWall = true;
        collidervar.sharedMaterial = slipvar;
        }
        Debug.Log("touching wall");
        
        


        

        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (iscorrectground(collision)) {
        isTouchingWall = false;
        collidervar.sharedMaterial = emptymat;
        }
        Debug.Log("not touching wall");


    }

    protected override void Update2()
    {
        base.Update2();
        Debug.Log("ling lang lung"+collidervar.sharedMaterial);
    }

}
