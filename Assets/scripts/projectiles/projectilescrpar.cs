using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class projectilescrpar :  basescript
{

    public float moveSpeed = 1f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    public float moveInput;

    public int xdirection=1;
    public int damage=5;
    private BoxCollider2D boxcollider2Dvar;

    public characterscr currentcharacter;
    private float angle2;

    private Vector2 direction;
    


    

    public virtual void setangle(float angle3) {
        angle2 = angle3;
    }

    protected override void Start2()
    {
        base.Start2();
        rb = GetComponent<Rigidbody2D>();
        boxcollider2Dvar = GetComponent<BoxCollider2D>();
       // disableprojectile();
        //gameObject.transform.rotation=quaternion.Euler(0,0,90);
        //boxcollider2Dvar.enabled = true;

        direction = new Vector2(Mathf.Cos(angle2 * Mathf.Deg2Rad), Mathf.Sin(angle2 * Mathf.Deg2Rad));

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Conversion en degrés

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        
    }


    public void enableprojectile() {
        boxcollider2Dvar.enabled = true;
    }

    protected virtual void disableprojectile() {
        boxcollider2Dvar.enabled = false;
        float duration = 1/moveSpeed;
        Invoke("enableprojectile",0.05f);
    }




    protected override void Update2()
    {
        base.Update2();

        
         // Angle en degrés
        //float speed = 5f;
        

        
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;


       // rb.velocity = new Vector2(transform.up.x * moveSpeed,transform.up.y * moveSpeed);

        
        
        //gameObject.transform.rotation=quaternion.Euler(0,0,90);
        
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        projectilescrpar otherprojectile= collision.gameObject.GetComponent<projectilescrpar>();
        characterscr othercharacter = collision.gameObject.GetComponent<characterscr>();
        isonground otherisonground = collision.gameObject.GetComponent<isonground>();

        if (otherprojectile == null && othercharacter == null && otherisonground==null) {
             oncollisiondestroy();
         }

        if (othercharacter!=null) {
            if (othercharacter!=currentcharacter) {
            othercharacter.takedamage(damage);
            oncollisiondestroy();
            }
        }
    }

    public void beginrange(float range) {
        float range2 = range/moveSpeed;
        Invoke("endrange",range2);
    }

    private void endrange() {
        Destroy(gameObject);
    }

    private void oncollisiondestroy() {
    Destroy(gameObject);
    }




}
