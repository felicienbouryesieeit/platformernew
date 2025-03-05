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









    protected override void beginanimator()
    {
        base.beginanimator();
        baseimage = "ennemy1";
        animationlist = new List<List<int>> {
    //idle
    new List<int> { 0},
    //walk
    new List<int> { 1,2 },
    //fall
    new List<int> { 3 }
};
    }


}
