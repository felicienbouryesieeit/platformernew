using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbehavior : characterbehaviorpar
{
    [SerializeField]
    private GameObject camera;
    [SerializeField] private LayerMask wallLayer; 
    private bool _isTouchingWall = false;
    private bool _isGrounded = false;
    private Rigidbody2D _rb;

    private float updown;

    [SerializeField]
    private GameObject heartuiobject;

    // Variables pour le dash
    [SerializeField] private float doubleTapThreshold = 0.3f; // Temps max entre deux pressions pour un dash
    [SerializeField] private float dashForce = 15f;           // Force appliquée lors du dash
    [SerializeField] private float dashDuration = 0.2f;         // Durée du dash
    [SerializeField] private float dashCooldown = 1f;           // Temps d'attente entre 2 dash
    private float lastRightTapTime = -1f;
    private float lastLeftTapTime = -1f;
    private bool isDashing = false;
    private bool canDash = true;
    private heartuiscr heartuivar;
    private GameObject heartuiobject2;

    protected override void Start2()
    {
        base.Start2();
        _rb = GetComponent<Rigidbody2D>();
        //charactervar = GetComponent<characterscr>();
    }

    public override void begincharacterbehavior()
    {
        base.begincharacterbehavior();
        gamemanagervar.playercharacter = this.charactervar;
        Debug.Log("soucoupe" + charactervar);
        Debug.Log("soucoupe chien" + (gamemanagervar == null));
        resetlifevoid();
    }

    public override void ondamage()
    {
        base.ondamage();
        resetlifevoid();
    }

    private void resetlifevoid()
    {
        if (heartuiobject2!=null) {
            Destroy(heartuiobject2);
        }
        heartuiobject2 = Instantiate(heartuiobject);
        heartuivar = heartuiobject2.GetComponent<heartuiscr>();
        heartuivar.beginheart(this);
        
    }

    public override void UpdateBehavior()
    {
        base.UpdateBehavior();
        
        // Déplacement de la caméra
        camera.transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            camera.transform.position.z
        );

        // Gestion du dash - vérification des doubles appuis sur D (droite) et A (gauche)
        if (canDash && !isDashing)
        {
            if (Input.GetKeyDown(KeyCode.V)){
                if (charactervar.xdirection==-1) 
                {
                    StartCoroutine(Dash(-1));
                } else {
                    StartCoroutine(Dash(1));
                }
                 
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (Time.time - lastRightTapTime < doubleTapThreshold)
                {
                    StartCoroutine(Dash(1)); // Dash vers la droite
                }
                lastRightTapTime = Time.time;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (Time.time - lastLeftTapTime < doubleTapThreshold)
                {
                    StartCoroutine(Dash(-1)); // Dash vers la gauche
                }
                lastLeftTapTime = Time.time;
            }
        }
        if (!isDashing)
        {
            charactervar.moveInput = Input.GetAxis("Horizontal");
        }
        else
        {
            charactervar.moveInput = 0;
        }

        Debug.Log("minecraft" + charactervar.moveInput);

        updown = Input.GetAxis("Vertical");
       
        
        //Mathf.Abs()
        if (Input.GetKeyDown(KeyCode.X ))
        {
            charactervar.Jump();
        }

        // Gestion du tir
        if (Input.GetKeyDown(KeyCode.C))
        {
            float angleshoot = 0;
            
            if (MathF.Abs(updown) > 0.1f)
            {
                Debug.Log("sasha : " + updown);
                angleshoot = (updown > 0) ? 90f : 270f;
            }
            else
            {
                angleshoot = (charactervar.xdirection == 1) ? 0f : 180f;
            }

            charactervar.shoot(angleshoot, 10f, 5.0f);
            //charactervar.circleshoot(5,10f,10.0f);
        }
    }



    protected override void beginanimator()
    {
        base.beginanimator();
        baseimage = "player";
        beginanimator3(1);
    }



    private IEnumerator Dash(int direction)
    {
        isDashing = true;
        canDash = false;  // Désactive le dash pendant le cooldown
        float startTime = Time.time;
        while (Time.time < startTime + dashDuration)
        {
            // Appliquer la vélocité de dash (conserve la vélocité verticale actuelle)
            _rb.velocity = new Vector2(dashForce * direction, 0);//_rb.velocity.y);
            yield return null;
        }
        isDashing = false;
        // Attendre le cooldown avant d'autoriser un nouveau dash
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
