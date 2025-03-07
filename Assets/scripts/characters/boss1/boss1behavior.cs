using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1behavior : characterbehaviorpar
{
    [SerializeField]
    private List<GameObject> spawnobjects;


    protected override void endlistattackvoid()
    {
        base.endlistattackvoid();
        //begincadence();
        //stopcadence=false;
    }


    public override void UpdateBehavior()
    {
        base.UpdateBehavior();
        Debug.Log("zouzou : "+stopcadence);

    }

    protected override void beginanimator()
    {
        base.beginanimator();
        
        Debug.Log("etire"+charactervar.animatorvar);
        baseimage = "boss1";
        havecustomanimation=true;
        havecustomflipping=true;
        animationlist = new List<List<int>> {
    //attack 1 
    new List<int> { 4},
    //attack 2 3
    new List<int> { 5,0 },
    //attack 4
    new List<int> { 0 },
    new List<int> { 5 }
};
        animationdurationlist = new List<List<float>> {
    //attack 1 
    new List<float> { -1},
    //attack 2 3
    new List<float> { 0.2f,0.5f},
    //attack 4
    new List<float> { -1},
    new List<float> { -1}
};



    }

        public override void begincharacterbehavior()
    {
        base.begincharacterbehavior();
        settypeofmovement(1);
        foreach (var spawnobject in spawnobjects)
        {
            Debug.Log("objet : " + spawnobject.transform.position+" b : "+spawnpoints);
            spawnpoints.Add(spawnobject.transform.position);
            Destroy(spawnobject);
            
            

        }
        spawnpoints.Add(gameObject.transform.position);
        randomattackmax=4;
        beginistrigger();
        
    }








        protected override void oncadenceattack()
    {
        base.oncadenceattack();
        //charactervar.circleshoot(45,5,10f,10.0f);
        gameObject.transform.position = spawnpoints[currentrandomattack]; 
        stopcadence=true;
        //charactervar.animatorvar.animationspeed = 0.1f;
        switch(currentrandomattack){
            case 0:
            
            charactervar.setxdirection(1);
            charactervar.animatorvar.changecurrentanimation(0);
            beginlistattackvoid(2,1,3,1); 
            break;
            case 1:
            //charactervar.setxdirection(1);
            charactervar.setxdirection(-1);
            charactervar.animatorvar.changecurrentanimation(0);
            beginlistattackvoid(2,1,3,1); 
            break;
            case 2:
            //charactervar.animatorvar.animationspeed = 0.2f;
            charactervar.animatorvar.changecurrentanimation(2);
            beginlistattackvoid(10,0.2f,3,1); 
            break;
            case 3:
            //charactervar.animatorvar.animationspeed = 0.2f;
            charactervar.animatorvar.changecurrentanimation(3);
            //beginlistattackvoid(2,1,3); 
            break;
        }
        
    }

    protected override void onlistattackvoid()
    {
        base.onlistattackvoid();
        
        bool currentmodulo = (currentlistattack%2==0);
        int projectilenumberlist = 0;
        switch(currentrandomattack){
            case 0:
            
            projectilenumberlist=5;
            if (currentmodulo) {
            projectilenumberlist=6;
            }
            charactervar.shootshotgun(0,10,projectilenumberlist,10,10);
            
            break;

            case 1:

            projectilenumberlist=3;
            if (currentmodulo) {
            projectilenumberlist=4;
            }

            charactervar.shootshotgun(aimplayerangle(),10,projectilenumberlist,10,10);
            break;
            
            case 2:
           // charactervar.shootshotgun(aimplayerangle(),10,6,10,10); 
            charactervar.shoot(aimplayerangle(), 20f, 20.0f);
            break;
            
            case 3:
            
            break;
        }

    }





    /*
    
    */

    private void goto3() {
        charactervar.animatorvar.changecurrentanimation(1);
    }
    public override void onbeginanimation(int currentanimation, int currentframe, int animationlist, int currentallframes)
    {
        base.onbeginanimation(currentanimation, currentframe, animationlist, currentallframes);

        if (currentanimation==3) {
            Invoke("goto3",1.0f);
        } else {
        switch(currentrandomattack) {
                    case 3:
                    if (currentframe==0) {
                    
                    int numberofbullets2=8;
                    float shootangle=0;
                    bool typeofcircle= (currentallframes%4==0);

                    if (typeofcircle) {
                        numberofbullets2=12;
                        //shootangle=36;
                    }
                    charactervar.circleshoot(shootangle,numberofbullets2,10f,10.0f);
                    Debug.Log("all frames : "+currentallframes);
                    

                    } else {
                         if (currentallframes==9) {
                            Invoke("begincadence",1);
                            charactervar.animatorvar.stopanimation=true;
                         }
                    }
                    
                    break;
        }
        }
    }



}
