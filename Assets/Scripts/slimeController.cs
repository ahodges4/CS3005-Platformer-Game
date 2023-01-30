using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeController : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D myRB;
    Animator myAnim;
    public bool facingRight;
    float groundCheckRadius = 0.2f;

    bool grounded = false;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public bool isAggressive;

    //player detection
    public playerDetection playerClose;
    public playerDetectionClose playerNearby;
    GameObject player;
    bool jumping = false;

    //weapon
    public GameObject theProjectile;
    public float shootTime;
    public Transform shootFrom;
    public int chanceShootPercent;
    float nextShootTime;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = false;
        isAggressive = false;

        nextShootTime = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        //is touching Ground?
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("vVelocity", myRB.velocity.y);

        
        if(playerClose.nearby){
            isAggressive = true;
        }
        if(isAggressive) aggressive();
        
    }

    void flip(){//Change facing direction
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    //Movement
    IEnumerator leftJump(){
        myAnim.SetTrigger("jumping");
        yield return new WaitForSeconds(1);
        grounded = false;
        myAnim.SetBool("isGrounded", grounded);
        myRB.AddForce(new Vector2(-200,500));
        yield return new WaitForSeconds(1);
        jumping = false;
    }

    IEnumerator rightJump(){
        myAnim.SetTrigger("jumping");
        yield return new WaitForSeconds(1);
        grounded = false;
        myAnim.SetBool("isGrounded", grounded);
        myRB.AddForce(new Vector2(200,500));
        yield return new WaitForSeconds(1);
        jumping = false;
    }
    


    void aggressive(){//attacking
        myAnim.SetBool("Agressive", true);
        if(!playerNearby.nearby && !jumping){
            if(player.transform.position.x > transform.position.x){
                StartCoroutine(rightJump());
                jumping = true;
                if(!facingRight) flip();
                
            }
            else if(player.transform.position.x < transform.position.x){
                StartCoroutine(leftJump());
                jumping = true;
                if(facingRight) flip();
            }
        }

        //face the player
        if(player.transform.position.x > transform.position.x && !facingRight) flip();
        else if(player.transform.position.x < transform.position.x && facingRight) flip(); 

        //attack
        if(playerClose.nearby && nextShootTime<Time.time){
            nextShootTime = Time.time + shootTime;
            if(Random.Range(0,100) <= chanceShootPercent){
                Vector3 difference = player.transform.position - shootFrom.position;
                difference.Normalize();
                float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                Instantiate(theProjectile, shootFrom.position, Quaternion.Euler(new Vector3(0,0,angle)));
            }
        }

    }
}
