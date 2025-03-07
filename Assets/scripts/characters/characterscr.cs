using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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

    public int lifemax=3;
    public int life;

    public List<GameObject> listOfHearts;

    public int typeofmovement=0;

    

    [SerializeField]
    private GameObject[] projectilelist;

    //[SerializeField]
    private List<List<int>> animationlist;
    private List<List<float>> animationdurationlist;

    






    

    [SerializeField]
    private isonground isongroundvar;

    [SerializeField]
    private WallJump walljumpvar1;

    [SerializeField]
    private WallJump walljumpvar2;

    public animatorscr animatorvar;
    //private List<>

    private float pushx = 0;
    
    
    private string baseimage;
    [SerializeField]
    private float aircontrol = 1;


    

    





    protected override void Start2()
    {
        base.Start2();
        
        

        
        
        
        isongroundvar.beginisonground(this);
        
        //Debug.Log("ouaf ouaf "+spriteRenderervar.sprite);
        
        
        life=lifemax;
        rb = GetComponent<Rigidbody2D>();
        characterbehaviorvar=GetComponent<characterbehaviorpar>();
        if (characterbehaviorvar != null) {
        characterbehaviorvar.begincharacterbehavior();
        }
            }

    public void beginanimation(List<List<int>> animationlist2,string baseimage2
    ,List<List<float>> animationdurationlist2
    ) {
        SpriteRenderer spriteRenderervar=GetComponent<SpriteRenderer>();

        animatorvar = GetComponent<animatorscr>();
        animationlist=animationlist2;
        animationdurationlist= animationdurationlist2;
        
        baseimage=baseimage2;

        /*
        */
        animatorvar.beginanimator(spriteRenderervar,animationlist,animationdurationlist,baseimage);

    }

    










/*
    public void setxdirection2(bool xdirection2) {
        animatorvar.flipimage(xdirection2);
        if (xdirection2) {
            xdirection=1;
        } else {
            xdirection=-1;
        }

    }*/

    public void setxdirection(int xdirection2) {
        
            xdirection = xdirection2;
            
            animatorvar.flipimage(xdirection==-1);
            
    }


    public void setflipfunc2() {
        
        if (characterbehaviorvar.havecustomflipping==false) {
            setxdirection((int)Mathf.Sign(moveInput));
            }
    }



       // Update is called once per frame
    protected override void Update2()
    {
        base.Update2();

        Debug.Log("jump"+canjump);
        if (gameObject.transform.rotation!=quaternion.Euler(0, 0, 0)) {
        gameObject.transform.rotation=quaternion.Euler(0,0,0);
        }
        if (characterbehaviorvar != null) {
            characterbehaviorvar.UpdateBehavior();
        }
        //animatorvar.changecurrentanimation(0);
        if (Mathf.Abs(moveInput)>0.2) {
            
            if (xdirection != (int)Mathf.Sign(moveInput)) {
            //animatorvar.changecurrentanimation(1);
            
            setflipfunc2();
            
            

            }
            //xdirection=-xdirection;
            //animatorvar.flipimage(xdirection==-1);

            //Debug.Log("horizontal bus : " + xdirection + " " );
        } else {
            if (moveInput!=0) {
                moveInput=0;
                //animatorvar.changecurrentanimation(0);
            }
        
        
            
        }

        

        /*
        Debug.Log("groupe : " + (Mathf.Abs(moveInput)) + " " + (Mathf.Abs(moveInput)<0.2) );
        
        if (Mathf.Abs(moveInput)<0.2 && moveInput!=0 ) {
        
        moveInput=0;
        
        }
        Debug.Log("groupe bis : " + (Mathf.Abs(moveInput)));

        
        */
        float moveSpeed2=moveSpeed;
        if (isongroundvar.isongroundbool==true) {
            
        } else {
            //aircontrol1=aircontrol;
            moveSpeed2=moveSpeed*aircontrol;

        }

        print("speed :");
        if (rb!=null) {
        switch (typeofmovement) {
            case 0:
            
             rb.velocity = new UnityEngine.Vector2((moveInput * moveSpeed2)+pushx, rb.velocity.y);
             
             typeofanimation(0);
             break;

            case 1:
            rb.velocity = new UnityEngine.Vector2(moveInput * (moveSpeed), moveInputY * moveSpeed);
            
            break;
        }
        }
       

        
        // Vérifier si le joueur est au sol
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Saut
        
    }

    private void typeofanimation(int animationtype) {
        if (characterbehaviorvar.havecustomanimation==false) {
        switch (animationtype) {
            case 0:
            groundanimation();
            break;

            case 1:
            flyinganimation();
            break;
        }
        }
    }

    private void groundanimation() {
        if (isongroundvar.isongroundbool==false) {
            animatorvar.changecurrentanimation(2);
        } else {
            
            Debug.Log("louis"+(Mathf.Abs(moveInput)>0.2));
            if (Mathf.Abs(moveInput)>0.2) {
            animatorvar.changecurrentanimation(1);    
            } else {
            animatorvar.changecurrentanimation(0);
            }
            
        }
    }

    private void flyinganimation() {
        animatorvar.changecurrentanimation(0);
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
        bool iswalljumping = false;
        if (walljumpvar1.isTouchingWall || walljumpvar2.isTouchingWall) {
            
            
            if (isongroundvar.isongroundbool==false) {
            iswalljumping = true;
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
            if (iswalljumping==false) {
            canjump-=1;}
            }
            Jump2();
            }
    }

    private void Jump2(){
        rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpForce);

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
            /*
            if (i<life) {
                listOfHearts[i].SetActive(true);
            } else {
                listOfHearts[i].SetActive(false);
            }*/
        }
        
        characterbehaviorvar.ondamage();
        if (life<=0) {
            characterbehaviorvar.Ondeath();
            Destroy(gameObject);
        }
    }

    public void takedamage(int damageamount) {
        changelife(-damageamount);
    }
    public void shoot(float angle,float speed,float range){
        UnityEngine.Vector3 addposition = new UnityEngine.Vector3(0, 0,0);
        shoot2(addposition,angle,speed,range);
    }
    public void shoot2(UnityEngine.Vector3 addposition , float angle,float speed,float range) {
        GameObject projectile = Instantiate(projectilelist[0],(gameObject.transform.position+addposition),quaternion.Euler(0,0,90));

        projectilescrpar projectilescript = projectile.GetComponent<projectilescrpar>();

        projectilescript.moveSpeed = speed;
        projectilescript.setangle(angle);
        projectilescript.beginrange(range);
        projectilescript.currentcharacter = this;
    }

    public void shootroof(){
        //shoot2();
    }

    public void circleshoot(float angleplus,int numberofbullets,float speed,float range) {
        float angle2 = 360/numberofbullets;
        for (int i = 0; i < numberofbullets; i++)
        {
            // Affiche l'index et la couleur correspondante
            
            shoot((angle2*(i+1))+angleplus,speed,range);
        }
        
        
        
    }

    


    public void shootshotgun(float angleplus,float ecart,int numberofbullets,float speed,float range) {
        //numberofbullets-=1;
        float angle2 = ecart;
        bool ispair= (numberofbullets%2==0);
        //int numberofbullets2 = 0;

        
        int beginboucle2=0;
        int i2=0;
        //Debug.Log("shotgun : "+midboucle);
        if (ispair==true) {
            numberofbullets+=1;
        } else {
            
        }

        int midboucle = (numberofbullets/2)+1;

        for (int i = 0; i < numberofbullets; i++)
        {
            //bool canshoot=true;

            float angle3=angle2;

            //bool ispair2= (i%2==0);

            if (i>=midboucle) {
                beginboucle2-=1;
                i2=beginboucle2;
                
            } else {
                i2=i;
            }



            /*
            if (i!=0) {
                if (ispair2) {

                } else {

                }
            };*/



            if (ispair==true) {
                if (Mathf.Abs(i2)==1) {
                    angle3 = angle3*0.6f;
                }
            }

            if (ispair==true && i==0) {
            
            } else {
                shoot(((i2*angle3))+angleplus,speed,range);
            }
            /*
            if (ispair==true && i==0) {
                canshoot=false;
                
            }

            if (i==1) {
                angle3=angle2*0.8f;
            }

            if (canshoot==true) {
            
            if (numberofbullets>=numberofbullets2) {
            shoot(((i*angle3))+angleplus,speed,range);
            numberofbullets2+=1;
            }
            */
            /*
            if (numberofbullets>=numberofbullets2) {
            shoot(((i*-angle3))+angleplus,speed,range);
            numberofbullets2+=1;
            }

            }*/
            
        }
        

        
        
    }

    /*
    private void shootshotgun2(float angleplus,float speed,float range) {
        shoot(((i*angle2))+angleplus,speed,range);
    }*/


}
