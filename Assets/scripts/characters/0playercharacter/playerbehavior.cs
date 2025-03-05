using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbehavior : characterbehaviorpar
{
    [SerializeField]
    private GameObject camera;
    private float updown;

    protected override void Start2()
    {
        base.Start2();
        //charactervar = GetComponent<characterscr>();
        
    }

    public override void begincharacterbehavior()
    {
        base.begincharacterbehavior();
        gamemanagervar.playercharacter=this.charactervar;
        
        Debug.Log("soucoupe"+charactervar);
        Debug.Log("soucoupe chien"+(gamemanagervar==null));

    }
    public override void UpdateBehavior()
    {
        base.UpdateBehavior();
        camera.transform.position = new Vector3(
            gameObject.transform.position.x,
            gameObject.transform.position.y,
            camera.transform.position.z
        );

        
        charactervar.moveInput = Input.GetAxis("Horizontal");
        
        Debug.Log("minecraft"+charactervar.moveInput);

        updown = Input.GetAxis("Vertical");
       
        
        //Mathf.Abs()
        if (Input.GetKeyDown(KeyCode.X))
        {
            charactervar.Jump();

        }



        if (Input.GetKeyDown(KeyCode.C))
        {
            float angleshoot = 0;
            
            if (MathF.Abs(updown)>0.1) {
                Debug.Log("sasha : " + (updown));
                if (updown>0) {
                    Debug.Log("sasha dada : " + (updown));
                    angleshoot = 90;
                    
                } else {
                    Debug.Log("sasha dodo : " + (updown));
                    angleshoot = 270;
                }
            }
            else {
            if (charactervar.xdirection==1) {
                angleshoot = 0;
            } else {
                angleshoot = 180;
            };
            

        }

        charactervar.shoot(angleshoot,10f,5.0f);
        //charactervar.circleshoot(5,10f,10.0f);
        }
        
    }



}
