using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class characterbehaviorpar : basescript
{
    protected characterscr charactervar;
    private float cadence=1;
    protected List<List<int>> animationlist; 
    protected string baseimage;

    protected override void Start2()
    {
        base.Start2();
        //charactervar = GetComponent<characterscr>();
        Invoke("cadencevoid",1.0f);
        
    }

    public virtual void UpdateBehavior()
    {
        
        
    }

    public virtual void begincharacterbehavior() {
        charactervar = GetComponent<characterscr>();
        beginanimator2();
    }

    private void cadencevoid() {
        oncadenceattack();
        Invoke("cadencevoid",cadence);
    }

    protected virtual void oncadenceattack() {

    }

    protected virtual void followplayer(int stopdistance) {
        Debug.Log("mediavenir" + checkplayer());
        if (checkplayer()) {
        charactervar.moveInput = followplayerfloat(gamemanagervar.playercharacter.transform.position.x,gameObject.transform.position.x,stopdistance);
        }
    }

    protected virtual float followplayerfloat(float baseposition, float playerposition,int stopdistance) {
        
            float distance = Vector3.Distance(gamemanagervar.playercharacter.transform.position, gameObject.transform.position);
            Debug.Log("baguette : "+(distance>3));

        float stopdistance2=1.1f;
        switch (stopdistance) {
            case 0:
            stopdistance2=1.1f; break;
        }
        if (distance>stopdistance2) {
        if (baseposition>playerposition) {
            return 1;
        } else {
            return -1;
        }
        
        } else {
            return 0;
        }
}
    

    protected virtual void followplayerflying(int stopdistance) {
        if (checkplayer()) {
        charactervar.moveInput = followplayerfloat(gamemanagervar.playercharacter.transform.position.x,gameObject.transform.position.x,stopdistance);
        charactervar.moveInputY = followplayerfloat(gamemanagervar.playercharacter.transform.position.y,gameObject.transform.position.y,stopdistance);
        }
    }


    private bool checkplayer() {
        return (gamemanagervar.playercharacter!=null);
    }

    protected void settypeofmovement(int type) {
        charactervar.typeofmovement = type;
        switch (type) {
            case 1:
            charactervar.rb.gravityScale = 0;
            break;
        }
    }

    private void beginanimator2() {
        beginanimator();
        
        charactervar.beginanimation(animationlist,baseimage);
    }


    protected virtual void beginanimator() {
        /*
        
        
        */

    }
}
