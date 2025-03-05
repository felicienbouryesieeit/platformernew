using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemy1behavior : characterbehaviorpar
{
    protected override void oncadenceattack()
    {
        base.oncadenceattack();
        charactervar.circleshoot(45,5,10f,10.0f);
    }

    public override void UpdateBehavior()
    {
        base.UpdateBehavior();
        followplayer(0);
    }

}
