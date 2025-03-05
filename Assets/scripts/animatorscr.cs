using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorscr : basescript
{
private SpriteRenderer spriteRenderervar;
public Sprite[] sprites;
public int currentframe;
private List<List<int>> animationlist;
private int currentanimation;

public void beginanimator(SpriteRenderer spriteRenderervar2,List<List<int>> animationlist2,string baseimage) {
    sprites = Resources.LoadAll<Sprite>(baseimage);
    spriteRenderervar=spriteRenderervar2;
    animationlist=animationlist2;
    

    Invoke("updateanimator", 0.1f);

}

public void changecurrentanimation(int currentanimation2) {
    
    if (currentanimation!=currentanimation2) {
    Debug.Log("current!");
    currentanimation = currentanimation2;
    currentframe=0;
    }
}

public void updateanimator() {

spriteRenderervar.sprite=sprites[animationlist[currentanimation][currentframe]];

currentframe+=1;
if (currentframe==animationlist[currentanimation].Count) {
    currentframe=0;
} else {

}
Debug.Log("current anim : "+ currentanimation +" current frame : "+currentframe + " current frame max : "+animationlist[currentanimation].Count);
Invoke("updateanimator", 0.1f);
}


public void flipimage(bool isflipping) {
    spriteRenderervar.flipX=isflipping;
}
}
