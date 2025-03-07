using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorscr : basescript
{
private SpriteRenderer spriteRenderervar;
public Sprite[] sprites;
public int currentframe;
private List<List<int>> animationlist;
private List<List<float>> animationdurationlist;
private int currentanimation;
public float animationspeed=0.1f;
private int currentallframes;

public bool stopanimation;

private characterbehaviorpar characterbehaviorvar;

    protected override void Start2()
    {
        base.Start2();
        characterbehaviorvar=GetComponent<characterbehaviorpar>();
    }

    public void beginanimator(SpriteRenderer spriteRenderervar2,List<List<int>> animationlist2,List<List<float>> animationdurationlist2,string baseimage) {
    sprites = Resources.LoadAll<Sprite>(baseimage);
    spriteRenderervar=spriteRenderervar2;
    animationlist=animationlist2;
    animationdurationlist=animationdurationlist2;
    

    
    Invoke("updateanimator", animationspeed);

}

public void changecurrentanimation(int currentanimation2) {
    
    if (currentanimation!=currentanimation2) {
    Debug.Log("current!");
    currentanimation = currentanimation2;
    currentframe=0;
    currentallframes=0;
    if (stopanimation==true) {
        stopanimation=false;
        updateanimator();
        //Invoke("updateanimator", animationspeed);
    }
    
    }
}

public void updateanimator() {
float animationspeed2 = animationspeed;
spriteRenderervar.sprite=sprites[animationlist[currentanimation][currentframe]];

characterbehaviorvar.onbeginanimation(currentanimation,currentframe,animationlist[currentanimation][currentframe],currentallframes);


currentallframes+=1;
currentframe+=1;
if (currentframe==animationlist[currentanimation].Count) {
    currentframe=0;
} else {

}
if (animationdurationlist.Count==animationlist.Count) {
    if (animationlist[currentanimation].Count==animationdurationlist[currentanimation].Count) {
        if (animationdurationlist[currentanimation][currentframe]!=-1){
            animationspeed2 = animationdurationlist[currentanimation][currentframe];
        };
    }

}
//Debug.Log("current anim : "+ currentanimation +" current frame : "+currentframe + " current frame max : "+animationlist[currentanimation].Count);
if (stopanimation==false) {
Invoke("updateanimator", animationspeed2);
}

}


public void flipimage(bool isflipping) {
    spriteRenderervar.flipX=isflipping;
}
}
