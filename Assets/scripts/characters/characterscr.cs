using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class characterscr : physicbasescript
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody2D rb;
    private characterbehaviorpar characterbehaviorvar;
    public int canjump;
    public int canjumpmax=1;
    public float moveInput;
    public float moveInputY;

    public int xdirection=1;

    private int lifemax=3;
    private int life;

    public List<GameObject> listOfHearts;

    public int typeofmovement=0;

    

    [SerializeField]
    private GameObject[] projectilelist;

    //[SerializeField]
    private List<List<int>> animationlist;

    






    

    [SerializeField]
    private isonground isongroundvar;

    [SerializeField]
    private WallJump walljumpvar1;

    [SerializeField]
    private WallJump walljumpvar2;

    private animatorscr animatorvar;

    private float pushx = 0;
    



    protected override void Start2()
    {
        base.Start2();
        
        animationlist = new List<List<int>> {
    //idle
    new List<int> { 1},
    //walk
    new List<int> { 1,2 }
};

        SpriteRenderer spriteRenderervar=GetComponent<SpriteRenderer>();
        animatorvar = GetComponent<animatorscr>();
        animatorvar.beginanimator(spriteRenderervar,animationlist);
        
        isongroundvar.beginisonground(this);
        
        //Debug.Log("ouaf ouaf "+spriteRenderervar.sprite);
        
        
        life=lifemax;
        rb = GetComponent<Rigidbody2D>();
        characterbehaviorvar=GetComponent<characterbehaviorpar>();
        if (characterbehaviorvar != null) {
        characterbehaviorvar.begincharacterbehavior();
        }
            }

    // Update is called once per frame
    protected override void Update2()
    {
        base.Update2();

        
        if (gameObject.transform.rotation!=quaternion.Euler(0, 0, 0)) {
        gameObject.transform.rotation=quaternion.Euler(0,0,0);
        }
        if (characterbehaviorvar != null) {
            characterbehaviorvar.UpdateBehavior();
        }

        if (Mathf.Abs(moveInput)>0.2) {
            if (xdirection != (int)Mathf.Sign(moveInput)) {
            
            xdirection = (int)Mathf.Sign(moveInput);
            animatorvar.flipimage(xdirection==-1);
            animatorvar.changecurrentanimation(1);

            }

            Debug.Log("horizontal bus : " + xdirection + " " );
        } else {
            if (moveInput!=0) {
                moveInput=0;
                animatorvar.changecurrentanimation(0);
            }
            
        }

        /*
        Debug.Log("groupe : " + (Mathf.Abs(moveInput)) + " " + (Mathf.Abs(moveInput)<0.2) );
        
        if (Mathf.Abs(moveInput)<0.2 && moveInput!=0 ) {
        
        moveInput=0;
        
        }
        Debug.Log("groupe bis : " + (Mathf.Abs(moveInput)));
        */
        switch (typeofmovement) {
            case 0:
             rb.velocity = new Vector2((moveInput * moveSpeed)+pushx, rb.velocity.y);
             break;

            case 1:
            rb.velocity = new Vector2(moveInput * moveSpeed, moveInputY * moveSpeed);
            break;
        }
       

        
        // VÃ©rifier si le joueur est au sol
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Saut
        
    }

    public void stopwalljump() {
        pushx -= Mathf.Sign(pushx);
        if (Mathf.Abs(pushx) <= 0) {
            pushx = 0;
        }
        else {
            Invoke("stopwalljump",0.1f);
        }
        
    }

    public void Jump() {
        if (walljumpvar1.isTouchingWall || walljumpvar2.isTouchingWall) {
            
            if (isongroundvar.isongroundbool==false) {
            pushx = 10;
            if (walljumpvar1.isTouchingWall) {
            pushx = -pushx;
            }
            Jump2();
            Invoke("stopwalljump",0.1f);
            }
            
        }
        if (canjump!=0) {
            if (isongroundvar.isongroundbool==false) {
            canjump-=1;
            }
            Jump2();
            }
    }

    private void Jump2(){
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    }



    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("patata" +canjump+" "+ (collision.gameObject.transform.position.y<this.transform.position.y));
        
        if (collision.gameObject.transform.position.y<this.transform.position.y) {
        canjump=canjumpmax;
        Debug.Log("doudou"+canjump);
        }
        
    }*/

    public void changelife(int currentlife) {

        life += currentlife;
        for (int i = 0; i < lifemax; i++)
        {
            if (i<life) {
                listOfHearts[i].SetActive(true);
            } else {
                listOfHearts[i].SetActive(false);
            }
        }
        if (life<=0) {
            Destroy(gameObject);
        }
    }

    public void takedamage(int damageamount) {
        changelife(-damageamount);
    }

    public void shoot(float angle,float speed,float range) {
        GameObject projectile = Instantiate(projectilelist[0],gameObject.transform.position,quaternion.Euler(0,0,90));

        projectilescrpar projectilescript = projectile.GetComponent<projectilescrpar>();

        projectilescript.moveSpeed = speed;
        projectilescript.setangle(angle);
        projectilescript.beginrange(range);
        projectilescript.currentcharacter = this;
    }

    public void circleshoot(float angleplus,int numberofbullets,float speed,float range) {
        float angle2 = 360/numberofbullets;
        for (int i = 0; i < numberofbullets; i++)
        {
            // Affiche l'index et la couleur correspondante
            
            shoot((angle2*(i+1))+angleplus,speed,range);
        }
        
        
    }

    


}
