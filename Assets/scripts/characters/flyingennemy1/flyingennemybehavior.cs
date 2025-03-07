using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingennemybehavior : characterbehaviorpar
{

protected override void oncadenceattack()
    {
        base.oncadenceattack();
        charactervar.circleshoot(0,4,10f,10.0f);
    }
    public override void begincharacterbehavior()
    {
        base.begincharacterbehavior();
        settypeofmovement(1);
    }

    public override void UpdateBehavior()
    {
        base.UpdateBehavior();
        followplayerflying(0);
        
    }


    




    protected override void beginanimator()
    {
        base.beginanimator();
        baseimage = "flyingennemy1";
        beginanimator3(0);
        
    }
}
 