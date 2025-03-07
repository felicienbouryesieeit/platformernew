using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class characterbehaviorpar : basescript
{
    public characterscr charactervar;
    private float cadence=1;
    protected List<List<int>> animationlist; 
    protected List<List<float>> animationdurationlist= new List<List<float>>(); 
    protected string baseimage;
    protected List<Vector3> spawnpoints = new List<Vector3>();
    protected int currentrandomattack;
    protected int randomattackmax;

    protected bool istrigger;
    protected bool stopcadence;
    protected int listattackmax;
    protected int currentlistattack;
    protected float cadencelistattack;

    protected float cadenceafterlistattack;
    public bool havecustomanimation;
    public bool havecustomflipping;




    protected void currentlistattackvoid() {

        onlistattackvoid();
        if (listattackmax!=currentlistattack) {
            currentlistattack+=1;

            Invoke("currentlistattackvoid",cadencelistattack);
        } else {
            Invoke("endlistattackvoid",cadenceafterlistattack);
            
        }
    }

    protected virtual void onlistattackvoid() {

    }

    protected void beginlistattackvoid(int listattackmax2,float cadencelistattack2, float aftercadencelistattack2,float beginwait) {
        currentlistattack=0;
        cadencelistattack=cadencelistattack2;
        listattackmax=(listattackmax2-1);
        cadenceafterlistattack=aftercadencelistattack2;
        Invoke("currentlistattackvoid",beginwait);
        
    }

    protected virtual void endlistattackvoid() {
        begincadence();
    }

    protected void beginistrigger() {
            istrigger=true;
            CapsuleCollider2D capsuleCollidervar = GetComponent<CapsuleCollider2D>();
            capsuleCollidervar.isTrigger = true;
    }
    protected override void Start2()
    {
        base.Start2();
        //charactervar = GetComponent<characterscr>();
        
        
        setrandomcurrentattack();
        
    }

    protected void setrandomcurrentattack() {
        if (randomattackmax!=0) {
        int currentrandomattack2=Random.Range(0, randomattackmax);;
        while (currentrandomattack2==currentrandomattack) {
            currentrandomattack2=Random.Range(0, randomattackmax);
        } 
        currentrandomattack=currentrandomattack2;
        
        }
        Debug.Log("random attack : "+currentrandomattack+" "+randomattackmax);
    }

    public virtual void UpdateBehavior()
    {
        
        
    }

    public virtual void begincharacterbehavior() {
        charactervar = GetComponent<characterscr>();
        beginanimator2();
        begincadence();
        
        
    }

    private void cadencevoid() {
        stopcadence=false;
        setrandomcurrentattack();
        oncadenceattack();
        begincadence2();
        
        
    }

    protected void begincadence() {
    stopcadence=false;
    begincadence2();
    }

    private void begincadence2() {
        if (stopcadence==false) {
        Invoke("cadencevoid",cadence);
        }
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
        
        charactervar.beginanimation(animationlist,baseimage,animationdurationlist
        );
    }


    protected virtual void beginanimator() {
        
        //beginanimator3(0);

    }

    public virtual void ondamage() {

    }

    protected void beginanimator3(int typeofanimation) {
        switch (typeofanimation) {
            case 0: animationlist = new List<List<int>> {
                        //idle
                        new List<int> {0,1},
                    };
            break;


            case 1:animationlist = new List<List<int>> {
    //idle
    new List<int> { 1},
    //walk
    new List<int> { 1,2 },
    //fall
    new List<int> { 3 }
};
            break;


            
        }

    }


    public virtual void onbeginanimation(int currentanimation,int currentframe,int animationlist,int currentallframes) {

    }

    protected float aimplayerangle() {
        float aimvalue=0;
        if (checkplayer()) {
        Vector2 direction = gamemanagervar.playercharacter.transform.position - gameObject.transform.position;
        aimvalue = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        }
        return aimvalue;
    }


    
}
