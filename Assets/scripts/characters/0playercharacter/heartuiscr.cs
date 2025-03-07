using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartuiscr : basescript
{
    public Canvas canvas; // Assigne le Canvas via l'Inspector
    public Sprite imageSprite; // Assigne l'image via l'Inspector
    
    private playerbehavior playerbehaviorvar;

    private List<GameObject> heartlist;
    protected override void Start2()
    {
        base.Start2();
        


        
    }

    public void beginheart(playerbehavior playerbehaviorvar2) {
        playerbehaviorvar = playerbehaviorvar2;

        spawnhearts();


    }

    public void spawnhearts() {
        for (int i = 0; i < playerbehaviorvar.charactervar.life; i++)
{
    spawnhearts2(i);
}

        
    }


    private void spawnhearts2(float decalage) {
        
        GameObject imageObject = new GameObject("NewImage");
        ;

        Image imageComponent = imageObject.AddComponent<Image>();
        imageComponent.sprite = imageSprite;

        
        imageObject.transform.SetParent(canvas.transform, false);

       
        RectTransform rectTransform = imageObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(50, 50); //60
        
        rectTransform.anchorMin = new Vector2(0, 1); 
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.anchoredPosition = new Vector2((43+(decalage*50)), -50);; 
        //heartlist.Add(imageObject);
    }
}
